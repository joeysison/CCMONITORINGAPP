using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccMonitoringApp.dlls
{
    public class clsDBValues
    {
        //connection
        public static string connectionClassTrav = "dbConnectionTrav";
        //login
        public static string getUserID = "spGetUserID";

        public static string insertDataLog = "spInsertCreditCardLogs";
        public static string getCompanyNameAll = "select fullname, ProfileNumber, PhoneNumber4 from Profiles where FullName <>'' and PhoneNumber4 <>'' and ProfileType = 0 order by fullname";
        public static string getSpecificCompany = "select fullname, ProfileNumber, PhoneNumber4 from Profiles where FullName <>'' and PhoneNumber4 <>'' and ProfileType = 0 ";
        public static string getFormula = "select Formula from tbl_ccformula where ";
        public static string getTransData = "select * from [dbo].[fnSearch_CCRecord] ";
        public static string cancelTransData = "update tbl_CCTrans set STATUS = 'XD',";


    }
}
