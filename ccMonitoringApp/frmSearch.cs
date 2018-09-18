using System;
using System.Windows.Forms;
using ccMonitoringApp.dlls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace ccMonitoringApp
{
    public partial class frmSearch : Form
    {
        private clsDBTravData _TravData = new clsDBTravData();
        private string userlogged;

        public frmSearch()
        {
            InitializeComponent();
        }

        public SqlConnection dbConnection
        {
            get { return _TravData.dbConnection; }
            set { _TravData.dbConnection = value; }
        }

        private void activateCancelBtn()
        {
            if (_TravData.dsData.Tables[0].Rows[0]["STATUS"].ToString() == "AC")
            {
                txtStatus.Text = "ACTIVE";
                btnCancel.Visible = true;
            }
            else
            {
                txtStatus.Text = "CANCELED";
                btnCancel.Visible = false;
            }
        }


        private void assignData()
        {
            txtTransDate.Text = Convert.ToDateTime(_TravData.dsData.Tables[0].Rows[0]["TransDate"].ToString()).ToShortDateString();
            txtCCCNumber.Text = _TravData.dsData.Tables[0].Rows[0]["NumberCode"].ToString();
            txtProfileNumber.Text = _TravData.dsData.Tables[0].Rows[0]["ProfileNumber"].ToString();
            txtCompanyName.Text = _TravData.dsData.Tables[0].Rows[0]["CompanyName"].ToString();
            txtPaxName.Text = _TravData.dsData.Tables[0].Rows[0]["PaxName"].ToString();
            txtChargedTo.Text = _TravData.dsData.Tables[0].Rows[0]["ChargedTo"].ToString();
            txtReloc.Text = _TravData.dsData.Tables[0].Rows[0]["Reloc"].ToString();
            txtReturnDate.Text = _TravData.dsData.Tables[0].Rows[0]["TravelReturnDate"].ToString();

            if (_TravData.dsData.Tables[0].Rows[0]["BTA"].ToString().Equals("Y"))
                chkBTA.Checked = true;
            else
                chkBTA.Checked = false;

            txtCurrency.Text = _TravData.dsData.Tables[0].Rows[0]["Currency"].ToString();
            txtAirFare.Text = Convert.ToDouble(_TravData.dsData.Tables[0].Rows[0]["FareAmt"]).ToString("N", CultureInfo.InvariantCulture);
            txtOtherFee.Text = Convert.ToDouble(_TravData.dsData.Tables[0].Rows[0]["OtherAmt"]).ToString("N", CultureInfo.InvariantCulture);
            txtBCDFee.Text = Convert.ToDouble(_TravData.dsData.Tables[0].Rows[0]["BCDAmt"]).ToString("N", CultureInfo.InvariantCulture);
            txtAdminFee.Text = Convert.ToDouble(_TravData.dsData.Tables[0].Rows[0]["AdminAmt"]).ToString("N", CultureInfo.InvariantCulture);
            txtTotalAmt.Text = Convert.ToDouble(_TravData.dsData.Tables[0].Rows[0]["TotalAmt"]).ToString("N", CultureInfo.InvariantCulture);
            txtRemarks.Text = _TravData.dsData.Tables[0].Rows[0]["Remarks"].ToString();

            activateCancelBtn();

            txtUserName.Text = _TravData.dsData.Tables[0].Rows[0]["LoggedBy"].ToString();
            txtCancelBy.Text = _TravData.dsData.Tables[0].Rows[0]["EditedBy"].ToString();

        }

        private void commandButtonAction(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            try
            {
                if (btnClick.Name.ToString().Equals("btnSearch"))
                {
                    if (txtRefNumSrch.Text != "")
                    {
                        var newString = txtRefNumSrch.Text.PadLeft(10, '0');
                        txtRefNumSrch.Text = newString;

                        string sqlStmt = clsDBValues.getTransData + newString + "'";

                        _TravData.getDataTrav(sqlStmt, "tbl_CCtrans");

                        assignData();

                        activateCancelBtn();

                    }
                    else
                    {
                        MessageBox.Show("Please input REFERENCE NUMBER", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (btnClick.Name.ToString().Equals("btnCancel"))
                {
                    if (txtRefNumSrch.Text != "")
                    {
                        var newString = txtRefNumSrch.Text.PadLeft(10, '0');
                        txtRefNumSrch.Text = newString;

                        string sqlStmt = clsDBValues.cancelTransData + " EditedBy ='" + userlogged + "', EditedDate = GETDATE() where NumberCode ='" + newString + "'";

                        var resp = MessageBox.Show("Are you sure you want to cancel this transaction?", ":: INFORMATION ::", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        if (resp == DialogResult.OK)
                        {
                            _TravData.getDataTrav(sqlStmt, "tbl_CCtrans");

                            _TravData = null;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please input REFERENCE NUMBER", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _TravData = null;
                this.Close();
                return;
            }

        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            clsASP _ASP = new clsASP();

            userlogged = clsDBTrav.isLogged;

            if (!_ASP.connectASP())
            {
                MessageBox.Show(_ASP._errorStr, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ASP = null;
                //_TravData = null;
                txtUserName.Text = clsDBTrav.isLogged;
                //this.Close();
            }
            else
            {
                //userlogged = _ASP.getUserName();
                txtUserName.Text = clsDBTrav.isLogged;
                userlogged = clsDBTrav.isLogged;
                //_ASP.sendCmdWithResponseText("rt");
            }

            txtUserName.Text = clsDBTrav.isLogged;
        }
    }
}
