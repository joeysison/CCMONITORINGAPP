using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ccMonitoringApp.dlls
{

    class clsLoginData
    {
        private static SqlConnection objConn;
        public string _error;
        public string LoggedUser;
        public bool isError;
        public bool changedPass = false;

        public void makeConnection()
        {
            try
            {
                string cnStr = Properties.Settings.Default.dbConnectionTRAV;
                    //ConfigurationManager.ConnectionStrings[clsDBValues.connectionClassTrav].ConnectionString;
                objConn = new SqlConnection(cnStr);
                objConn.Open();

                //MessageBox.Show(objConn.State.ToString());

            }
            catch (Exception ex)
            {
                isError = true;
                _error = ex.Message;
                //MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void updatePassword(int vUserID, string vPassword)
        {
            SqlCommand objCmd = new SqlCommand();

            try
            {
                objCmd.CommandText = "update tbl_UserAccess set ChangePassword = 0, password = '" + vPassword + "' where userID = " + vUserID;
                objCmd.CommandType = CommandType.Text;
                objCmd.Connection = objConn;

                objCmd.ExecuteNonQuery();

                return;

            }catch(Exception ex)
            {
                isError = true;
                _error = ex.Message;
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        public int getUserID(string vUserName, string vPassword)
        {
            SqlCommand objCmd = new SqlCommand();

            try
            {
                objCmd.CommandText = clsDBValues.getUserID;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Connection = objConn;

                objCmd.Parameters.Add(new SqlParameter("@LoginName", SqlDbType.VarChar, 20));
                objCmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 20));
                objCmd.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int));
                objCmd.Parameters.Add(new SqlParameter("@sApplication", SqlDbType.VarChar, 50));
                objCmd.Parameters.Add(new SqlParameter("@Logged", SqlDbType.VarChar, 50));
                objCmd.Parameters.Add(new SqlParameter("@changedPassword", SqlDbType.Int));

                objCmd.Parameters["@LoginName"].Value = vUserName;
                objCmd.Parameters["@Password"].Value = vPassword;
                objCmd.Parameters["@iUserID"].Direction = ParameterDirection.Output;
                objCmd.Parameters["@sApplication"].Value = Properties.Settings.Default.appName.ToString();
                objCmd.Parameters["@Logged"].Direction = ParameterDirection.Output;
                objCmd.Parameters["@changedPassword"].Direction = ParameterDirection.Output;

                objCmd.ExecuteNonQuery();

                //MessageBox.Show(objCmd.Parameters["@Logged"].Value.ToString());

                if (objCmd.Parameters["@Logged"].Value.ToString() != "")
                {

                    if (Convert.ToInt32(objCmd.Parameters["@changedPassword"].Value.ToString()) == 1)
                        changedPass = true;

                    LoggedUser = objCmd.Parameters["@Logged"].Value.ToString();
                    return Convert.ToInt32(objCmd.Parameters["@iUserID"].Value);
                }
                else
                    return -1;


            }
            catch (SqlException ex)
            {
                isError = true;
                _error = ex.Message;
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

    }
}
