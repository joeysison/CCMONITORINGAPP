using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace ccMonitoringApp.dlls
{
    class clsDBTravData
    {
        private SqlConnection mdbConnection1 = new SqlConnection();
        private SqlDataAdapter objDA;

        public DataSet dsData = new DataSet();

        public SqlConnection dbConnection
        {
            get { return mdbConnection1; }
            set { mdbConnection1 = value; }
        }

        public string saveDataCredit(clsTravValues myGDSLog, int crtBy)
        {

            SqlTransaction sqlTrans = null;
            string rtnValue;

            try
            {
                SqlCommand objCmd = new SqlCommand();

                sqlTrans = mdbConnection1.BeginTransaction();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Connection = mdbConnection1;
                objCmd.CommandText = clsDBValues.insertDataLog;
                objCmd.Transaction = sqlTrans;

                objCmd.Parameters.Add(new SqlParameter("@Account", SqlDbType.VarChar, 30));
                objCmd.Parameters.Add(new SqlParameter("@TransDate", SqlDbType.Date));
                objCmd.Parameters.Add(new SqlParameter("@TravelReturnDate", SqlDbType.VarChar,8));
                objCmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 200));
                objCmd.Parameters.Add(new SqlParameter("@GCN", SqlDbType.VarChar, 4));
                objCmd.Parameters.Add(new SqlParameter("@ProfileNum", SqlDbType.VarChar, 10));
                objCmd.Parameters.Add(new SqlParameter("@PaxName", SqlDbType.VarChar, 50));
                objCmd.Parameters.Add(new SqlParameter("@ChargedTo", SqlDbType.VarChar, 50));
                objCmd.Parameters.Add(new SqlParameter("@Reloc", SqlDbType.VarChar, 6));
                objCmd.Parameters.Add(new SqlParameter("@BTA", SqlDbType.VarChar, 1));
                objCmd.Parameters.Add(new SqlParameter("@Currency", SqlDbType.VarChar, 3));
                objCmd.Parameters.Add(new SqlParameter("@FareAmt", SqlDbType.Decimal));
                objCmd.Parameters.Add(new SqlParameter("@OtherAmt", SqlDbType.Decimal));
                objCmd.Parameters.Add(new SqlParameter("@BCDAmt", SqlDbType.Decimal));
                objCmd.Parameters.Add(new SqlParameter("@AdminAmt", SqlDbType.Decimal));
                objCmd.Parameters.Add(new SqlParameter("@TotalAmt", SqlDbType.Decimal));
                objCmd.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.VarChar, 500));
                objCmd.Parameters.Add(new SqlParameter("@LoggedBy", SqlDbType.VarChar, 50));
                objCmd.Parameters.Add(new SqlParameter("@GDSManual", SqlDbType.VarChar, 1));
                objCmd.Parameters.Add(new SqlParameter("@cNextID", SqlDbType.VarChar, 10));

                objCmd.Parameters["@Account"].Value = myGDSLog.sCompanyID;
                objCmd.Parameters["@TransDate"].Value = myGDSLog.dTransDate;
                objCmd.Parameters["@TravelReturnDate"].Value = myGDSLog.sReturnDate;
                objCmd.Parameters["@CompanyName"].Value = myGDSLog.sCompanyName;
                objCmd.Parameters["@GCN"].Value = myGDSLog.sGCN;
                objCmd.Parameters["@ProfileNum"].Value = myGDSLog.sProfileNumber;
                objCmd.Parameters["@PaxName"].Value = myGDSLog.sPaxName;
                objCmd.Parameters["@ChargedTo"].Value = myGDSLog.sChargedTo;
                objCmd.Parameters["@Reloc"].Value = myGDSLog.sReloc;
                objCmd.Parameters["@BTA"].Value = myGDSLog.sBTA;
                objCmd.Parameters["@Currency"].Value = myGDSLog.sCurrency;
                objCmd.Parameters["@FareAmt"].Value = myGDSLog.dAirFareAmt;
                objCmd.Parameters["@OtherAmt"].Value = myGDSLog.dOthersAmt;
                objCmd.Parameters["@BCDAmt"].Value = myGDSLog.dBCDFeeAmt;
                objCmd.Parameters["@AdminAmt"].Value = myGDSLog.dAdminFeeAmt;
                objCmd.Parameters["@TotalAmt"].Value = myGDSLog.dTotalAmt;
                objCmd.Parameters["@Remarks"].Value = myGDSLog.sRemarks;
                objCmd.Parameters["@LoggedBy"].Value = myGDSLog.sLoggedBy;
                objCmd.Parameters["@GDSManual"].Value = myGDSLog.sGDSManual;
                objCmd.Parameters["@cNextID"].Direction = ParameterDirection.Output;

                objCmd.ExecuteNonQuery();

                sqlTrans.Commit();

                rtnValue = Convert.ToString(objCmd.Parameters["@cNextID"].Value);

                sqlTrans.Dispose();
                objCmd.Dispose();

                return rtnValue;
            }
            catch (SqlException ex)
            {
                sqlTrans.Rollback();
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }

        public void saveDataTrav(clsTravValues myGDSLog, int crtBy)
        {

            SqlTransaction sqlTrans = null;

            try
            {
                SqlCommand objCmd = new SqlCommand();

                sqlTrans = mdbConnection1.BeginTransaction();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Connection = mdbConnection1;
                objCmd.CommandText = clsDBValues.insertDataLog;
                objCmd.Transaction = sqlTrans;

                objCmd.ExecuteNonQuery();

                sqlTrans.Commit();

                sqlTrans.Dispose();
                objCmd.Dispose();
            }
            catch (SqlException ex)
            {
                sqlTrans.Rollback();
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public DataSet getDataTrav(string strSQL, string tblName)
        {

            DataSet ds = new DataSet();

            try
            {
                SqlCommand objCmd = new SqlCommand();
                objDA = new SqlDataAdapter(objCmd);

                objCmd.CommandText = strSQL;
                objCmd.CommandType = CommandType.Text;
                objCmd.Connection = mdbConnection1;

                //objDS.Clear();
                ds.Clear();
                objDA.Fill(ds, tblName);
                objDA.FillLoadOption = LoadOption.Upsert;

                dsData = ds;

                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ds;
            }
        }

    }
}
