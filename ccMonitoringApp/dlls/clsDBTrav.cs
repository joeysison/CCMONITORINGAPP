using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ccMonitoringApp.dlls
{
    class clsDBTrav
    {
        public static SqlConnection objConn;
        public static string isLogged;
        public static int UserID;

        public clsDBTrav()
        {

        }

        public static void makeConnection()
        {
            try
            {
                string cnStr = Properties.Settings.Default.dbConnectionTRAV;
                //ConfigurationManager.ConnectionStrings[clsDBValues.connectionClass].ConnectionString;
                objConn = new SqlConnection(cnStr);
                objConn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public static int getNextID(string vModule)
        //{
        //    SqlCommand mySqlCmd = new SqlCommand();
        //    SqlParameter paramModule;
        //    SqlParameter paramNextID;

        //    try
        //    {
        //        mySqlCmd.CommandText = "spGetNextSystemID";
        //        mySqlCmd.CommandType = CommandType.StoredProcedure;
        //        mySqlCmd.Connection = objConn;

        //        paramModule = mySqlCmd.Parameters.Add("@sModuleCode", SqlDbType.Text);
        //        paramModule.Direction = ParameterDirection.Input;
        //        paramModule.Value = vModule;

        //        paramNextID = mySqlCmd.Parameters.Add("@iNextID", SqlDbType.Int);
        //        paramNextID.Direction = ParameterDirection.Output;

        //        mySqlCmd.ExecuteNonQuery();

        //        return Convert.ToInt32(paramNextID.Value);

        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return -1;
        //    }
        //}

        //public static string inputBoxShow(String headerTitle, String okButton, String cancelButton, String labelTitle)
        //{
        //    rFrmInputBox myInputSerial = new rFrmInputBox();

        //    myInputSerial.headerTitle = headerTitle;
        //    myInputSerial.okButton = okButton;
        //    myInputSerial.cancelButton = cancelButton;
        //    myInputSerial.labelTitle = labelTitle;
        //    myInputSerial.ShowDialog();

        //    if (myInputSerial.DialogResult == DialogResult.OK)
        //    {
        //        return myInputSerial.resultDialogData;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

    }
}
