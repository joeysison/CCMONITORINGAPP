using System;
using System.Windows.Forms;
using ccMonitoringApp.dlls;
using System.Data.SqlClient;
using System.Data;

namespace ccMonitoringApp
{
    public partial class frmDataLog : Form
    {

        private clsDBTravData _TravData = new clsDBTravData();
        private clsTravValues _TravValues = new clsTravValues();
        private clsASP _ASP = new clsASP();
        private string refNo;

        public frmDataLog()
        {
            InitializeComponent();
        }

        public SqlConnection dbConnection
        {
            get { return _TravData.dbConnection; }
            set { _TravData.dbConnection = value; }
        }

        private void frmDataLog_Load(object sender, EventArgs e)
        {
            txtTransDate.Text = DateTime.Now.ToString("dd / MMM / yyyy");
            if (!_ASP.connectASP())
            {
                MessageBox.Show(_ASP._errorStr, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUserName.Text = clsDBTrav.isLogged;

                tabDataInput.SelectedIndex = 1;

                //_TravData = null;
                //_TravValues = null;
                //_ASP = null;
                //this.Close();

            }
            else
            {
                //txtUserName.Text = _ASP.getUserName();
                txtUserName.Text = clsDBTrav.isLogged;
                _ASP.sendCmdWithResponseText("rt");
            }
        }

        private void loadLookupData(bool isGDS, string gcnNumber)
        {
            if (isGDS)
            {
                cmbCompany.DataSource = _TravData.getDataTrav(clsDBValues.getSpecificCompany + "and PhoneType4 = 'mobile' and PhoneNumber4 = '" + gcnNumber + "' order by fullname", "company").Tables["company"];
                cmbCompany.DisplayMember = "FullName";
                //cmbCompany.ValueMember = "ProfileNumber";
            }
            else
            {
                cmbCompanyMan.DataSource = _TravData.getDataTrav(clsDBValues.getCompanyNameAll, "company").Tables["company"];
                cmbCompanyMan.DisplayMember = "FullName";
                //cmbCompanyMan.ValueMember = "PhoneNumber4";
            }

        }

        private void tabDataInput_Selected(object sender, TabControlEventArgs e)
        {
            if (tabDataInput.SelectedTab.Text == "MANUAL")
            {
                loadLookupData(false, "");
                btnGetGDSData.Visible = false;
                txtGCN.Text = "";
                txtAccntCode.Text = "";
                cmbCompany.Text = "";
                txtPaxName.Text = "";
                txtChargedTo.Text = "";
                txtReloc.Text = "";
                chkBTA.Checked = false;
                cmbCurrency.Text = "";
                txtAirFare.Text = "0.00";
                txtOtherFee.Text = "0.00";
                txtBCDFee.Text = "0.00";
                txtAdminFee.Text = "0.00";
                txtTotalAmt.Text = "0.00";
                txtCCCNumber.Text = "";
                txtClientProfile.Text = "";
                lblTicketCnt.Text = "";
                txtRemarks.Text = "";
                txtArrivalDate.Text = "dd-MMM";

            }
            else if (tabDataInput.SelectedTab.Text == "GDS")
            {
                btnGetGDSData.Visible = true;
                txtGCN.Text = "";
                txtAccntCode.Text = "";
                cmbCompanyMan.Text = "";
                txtPaxNameMan.Text = "";
                txtChargedToMan.Text = "";
                txtRelocMan.Text = "";
                chkBTAMan.Checked = false;
                cmbCurrencyMan.Text = "";
                txtAirFareMan.Text = "0.00";
                txtOtherFeeMan.Text = "0.00";
                txtBCDFeeMan.Text = "0.00";
                txtAdminFeeMan.Text = "0.00";
                txtTotalAmtMan.Text = "0.00";
                txtCCCNumber.Text = "";
                txtClientProfile.Text = "";
                txtRemarks.Text = "";
                txtArrivalDateMan.Text = "dd-MMM";
            }

            cmbCompanyMan.Text = "";
        }

        private void terminateProc()
        {
            _TravData = null;
            _TravValues = null;
            _ASP = null;

            this.Close();

        }

        private bool isCompleteData()
        {
            if (tabDataInput.SelectedTab.Text == "GDS")
            {
                if (txtGCN.Text == "" || txtClientProfile.Text == "" || Convert.ToDouble(txtTotalAmt.Text) == 0 || Convert.ToDouble(txtAdminFee.Text) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (txtGCN.Text == "" || txtClientProfile.Text == "" || Convert.ToDouble(txtTotalAmtMan.Text) == 0 || Convert.ToDouble(txtAdminFeeMan.Text) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private bool isDataExist()
        {
            string sqlstmt;
            //DataSet ds;

            sqlstmt = "select * from tbl_cctrans where reloc ='" + _TravValues.sReloc + "' and ProfileNumber ='" + _TravValues.sProfileNumber + "' and PaxName ='" + _TravValues.sPaxName + "' and  FareAmt ='" + _TravValues.dAirFareAmt.ToString() + "' and Status = 'AC'";

            _TravData.getDataTrav(sqlstmt, "ccLogs");

            if (_TravData.dsData.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < _TravData.dsData.Tables[0].Rows.Count;)
                {
                    refNo = refNo + " / " + _TravData.dsData.Tables[0].Rows[i]["NumberCode"].ToString();
                    i++;
                }
                return true;
            }
            else
            {
                refNo = "";
                return false;
            }
        }

        private void commandButtonAction(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;

            try
            {

                if (btnClick.Name.ToString() == "btnGetGDSData")
                {
                    //if (!_ASP.connectASP())
                    //{
                    //    MessageBox.Show(_ASP._errorStr, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    if (tabDataInput.SelectedTab.Text == "GDS")
                    {
                        txtReloc.Text = _ASP.getPNR();
                        if (_ASP._errorStr.Length > 1)
                        {
                            MessageBox.Show(_ASP._errorStr, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            terminateProc();
                            return;
                        }

                        string acctCodeString;
                        string[] acctCode;
                        string _gcn = "";

                        acctCodeString = _ASP.getRemarks("TID-", "TID-", "RM");
                        acctCode = acctCodeString.Split('-');

                        _gcn = acctCode[2];

                        txtAccntCode.Text = acctCodeString;
                        txtGCN.Text = _gcn;
                        loadLookupData(true, _gcn);

                        txtPaxName.Text = _ASP.getPax();
                        txtChargedTo.Text = txtPaxName.Text;

                        txtArrivalDate.Text = _ASP.getReturnTravelDate();

                        double tktAmt = Math.Round(_ASP.getTicketAmount(),2);
                        string tktCurr = _ASP.getFareCurr();

                        if (_ASP.ticketCount() > 1)
                        {
                            lblTicketCnt.Text = "Total Ticket Count - " + _ASP.ticketCount();
                        }

                        cmbCurrency.Text = tktCurr;
                        txtAirFare.Text = tktAmt.ToString("#,##0.00");

                        if (!_ASP.isPresentROE())
                            MessageBox.Show("Could not determine ROE, AIRFARE has no IPP, Please correct AIRFARE with IPP.", ":: INFORMATION ::", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _ASP.sendCmdWithResponseText("rt");

                    }
                    //}
                    return;
                }

                if (btnClick.Name.ToString() == "btnAdminFee")
                {
                    if (tabDataInput.SelectedTab.Text == "GDS")
                    {
                        if (txtGCN.Text == "" || txtAirFare.Text == "" || txtBCDFee.Text == "" || txtOtherFee.Text == "")
                        {
                            MessageBox.Show("Please select Company, Input AirFare / Other Fee / BCD Fee.", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            txtAdminFee.Text = computeData(txtGCN.Text, cmbCurrency.Text).ToString("#,##0.00");
                            txtTotalAmt.Text = (Convert.ToDouble(txtAirFare.Text) + Convert.ToDouble(txtOtherFee.Text) + Convert.ToDouble(txtBCDFee.Text) + Convert.ToDouble(txtAdminFee.Text)).ToString("#,##0.00");
                            return;
                        }
                    }
                    else
                    {
                        if (txtGCN.Text == "" || txtBCDFeeMan.Text == "" || txtOtherFeeMan.Text == "")
                        {
                            MessageBox.Show("Please select Company, Input AirFare / Other Fee / BCD Fee.", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            txtAdminFeeMan.Text = computeData(txtGCN.Text, cmbCurrencyMan.Text).ToString("#,##0.00");
                            txtTotalAmtMan.Text = (Convert.ToDouble(txtAirFareMan.Text) + Convert.ToDouble(txtOtherFeeMan.Text) + Convert.ToDouble(txtBCDFeeMan.Text) + Convert.ToDouble(txtAdminFeeMan.Text)).ToString("#,##0.00");
                            return;
                        }
                    }


                }

                if (btnClick.Name.ToString() == "btnSubmit")
                {
                    if (!isCompleteData())
                    {
                        MessageBox.Show("Please select Company, Input AirFare / Other Fee / BCD Fee.", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (tabDataInput.SelectedTab.Text == "GDS")
                    {
                        _TravValues.sCompanyID = txtAccntCode.Text;
                        _TravValues.sGCN = txtGCN.Text;
                        _TravValues.sProfileNumber = txtClientProfile.Text;
                        _TravValues.sPaxName = txtPaxName.Text;
                        _TravValues.sCompanyName = cmbCompany.Text;
                        _TravValues.sChargedTo = txtChargedTo.Text;
                        _TravValues.dTransDate = DateTime.Now;
                        _TravValues.sReturnDate = txtArrivalDate.Text;
                        _TravValues.sReloc = txtReloc.Text;
                        _TravValues.sCurrency = cmbCurrency.Text;
                        if (chkBTA.Checked)
                            _TravValues.sBTA = "Y";
                        else
                            _TravValues.sBTA = "N";

                        _TravValues.dAirFareAmt = Convert.ToDouble(txtAirFare.Text);
                        _TravValues.dOthersAmt = Convert.ToDouble(txtOtherFee.Text);
                        _TravValues.dBCDFeeAmt = Convert.ToDouble(txtBCDFee.Text);
                        _TravValues.dAdminFeeAmt = Convert.ToDouble(txtAdminFee.Text);
                        _TravValues.dTotalAmt = Convert.ToDouble(txtTotalAmt.Text);
                        _TravValues.sRemarks = txtRemarks.Text;
                        _TravValues.sLoggedBy = txtUserName.Text;
                        _TravValues.sGDSManual = "Y";

                    }
                    else
                    {
                        _TravValues.sCompanyID = txtAccntCode.Text;
                        _TravValues.sGCN = txtGCN.Text;
                        _TravValues.sProfileNumber = txtClientProfile.Text;
                        _TravValues.sPaxName = txtPaxNameMan.Text;
                        _TravValues.sCompanyName = cmbCompanyMan.Text;
                        _TravValues.sChargedTo = txtChargedToMan.Text;
                        _TravValues.dTransDate = DateTime.Now;
                        _TravValues.sReturnDate = txtArrivalDateMan.Text;
                        _TravValues.sReloc = txtRelocMan.Text;
                        _TravValues.sCurrency = cmbCurrencyMan.Text;
                        if (chkBTAMan.Checked)
                            _TravValues.sBTA = "Y";
                        else
                            _TravValues.sBTA = "N";

                        _TravValues.dAirFareAmt = Convert.ToDouble(txtAirFareMan.Text);
                        _TravValues.dOthersAmt = Convert.ToDouble(txtOtherFeeMan.Text);
                        _TravValues.dBCDFeeAmt = Convert.ToDouble(txtBCDFeeMan.Text);
                        _TravValues.dAdminFeeAmt = Convert.ToDouble(txtAdminFeeMan.Text);
                        _TravValues.dTotalAmt = Convert.ToDouble(txtTotalAmtMan.Text);
                        _TravValues.sRemarks = txtRemarksMan.Text;
                        _TravValues.sLoggedBy = txtUserName.Text;
                        _TravValues.sGDSManual = "N";
                    }

                    if (isDataExist())
                    {
                        var resp = MessageBox.Show("DATA is existing already. See REF NO: " + refNo + ". \n" + "Do you want to continue?", ":: ERROR ::", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (resp == DialogResult.Yes)
                        {
                            txtCCCNumber.Text = _TravData.saveDataCredit(_TravValues, 1);
                            MessageBox.Show("Saved Successfully... with REFNO: " + txtCCCNumber.Text, ":: SAVE ::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        txtCCCNumber.Text = _TravData.saveDataCredit(_TravValues, 1);
                        MessageBox.Show("Saved Successfully... with REFNO: " + txtCCCNumber.Text, ":: SAVE ::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }

                if (btnClick.Name.ToString() == "btnClear")
                {
                    if (tabDataInput.SelectedTab.Text == "GDS")
                    {
                        txtGCN.Text = "";
                        txtAccntCode.Text = "";
                        cmbCompany.Text = "";
                        txtPaxName.Text = "";
                        txtChargedTo.Text = "";
                        txtReloc.Text = "";
                        chkBTA.Checked = false;
                        cmbCurrency.Text = "";
                        txtAirFare.Text = "0.00";
                        txtOtherFee.Text = "0.00";
                        txtBCDFee.Text = "0.00";
                        txtAdminFee.Text = "0.00";
                        txtTotalAmt.Text = "0.00";
                        txtCCCNumber.Text = "";
                        lblTicketCnt.Text = "";
                        txtRemarks.Text = "";
                        txtArrivalDate.Text = "dd-MMM";

                    }
                    else
                    {
                        txtGCN.Text = "";
                        txtAccntCode.Text = "";
                        cmbCompanyMan.Text = "";
                        txtPaxNameMan.Text = "";
                        txtChargedToMan.Text = "";
                        txtRelocMan.Text = "";
                        chkBTAMan.Checked = false;
                        cmbCurrencyMan.Text = "";
                        txtAirFareMan.Text = "0.00";
                        txtOtherFeeMan.Text = "0.00";
                        txtBCDFeeMan.Text = "0.00";
                        txtAdminFeeMan.Text = "0.00";
                        txtTotalAmtMan.Text = "0.00";
                        txtCCCNumber.Text = "";
                        txtRemarksMan.Text = "";
                        txtArrivalDateMan.Text = "dd-MMM";
                    }

                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private double computeData(string GCN, string Currency)
        {
            string sqlStmnt = clsDBValues.getFormula + "GCNNo = '" + GCN + "' and Curr ='" + Currency + "'";
            string expression = _TravData.getDataTrav(sqlStmnt, "Formula").Tables["Formula"].Rows[0]["formula"].ToString();    //"cost * item / 100" (IT MUST BE SEPARATED WITH SPACES!)
            string variable1 = "airfare=";      //"item=10"
            string variable2 = "OtherFee=";      //"cost=2.5"
            string variable3 = "BCDFee=";
            double rslt;

            if (tabDataInput.SelectedTab.Text == "GDS")
            {
                variable1 = variable1 + txtAirFare.Text;      //"item=10"
                variable2 = variable2 + txtOtherFee.Text;      //"cost=2.5"
                variable3 = variable3 + txtBCDFee.Text;
            }
            else
            {
                variable1 = variable1 + txtAirFareMan.Text;      //"item=10"
                variable2 = variable2 + txtOtherFeeMan.Text;      //"cost=2.5"
                variable3 = variable3 + txtBCDFeeMan.Text;
            }


            //if (variable1 == "")
            //    variable1 = "airfare=0.00";
            //if (variable2 == "")
            //    variable2 = "OtherFee=0.00";
            //if (variable3 == "")
            //    variable3 = "BCDFee=0.00";

            DynamicFormula math = new DynamicFormula();
            math.Expression = expression;   //Let's define the expression
            math.AddVariable(variable1);
            math.AddVariable(variable2);
            math.AddVariable(variable3);

            try
            {
                rslt = math.CalculateResult(); //In this scenario the result is 0,25... cost * item / 100 = (2.5 * 10 / 100) = 0,25
                                                //Console.WriteLine("Success: " + result);
            }
            catch (Exception ex)
            {
                rslt = 0;
            }

            return Math.Round(rslt,2);
        }

        private void inputCheckInText(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                        && !char.IsDigit(e.KeyChar)
                        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private void cmbCompanyDrop_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmbComp = (ComboBox)sender;
            DataRowView selectedRos;

            try
            {
                if (cmbComp.Name.Equals("cmbCompanyMan"))
                {
                    selectedRos = (DataRowView)cmbComp.SelectedItem;
                    txtGCN.Text = selectedRos.Row["PhoneNumber4"].ToString();
                    txtClientProfile.Text = selectedRos.Row["ProfileNumber"].ToString();
                }
                else if (cmbComp.Name.Equals("cmbCompany"))
                {
                    selectedRos = (DataRowView)cmbComp.SelectedItem;
                    txtGCN.Text = selectedRos.Row["PhoneNumber4"].ToString();
                    txtClientProfile.Text = selectedRos.Row["ProfileNumber"].ToString();
                }

                return;

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void txtPaxNameMan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaxNameMan.Text))
            {
                txtChargedToMan.Clear();
                return;
            }
            txtChargedToMan.Text = txtPaxNameMan.Text;
        }

        private void txtPaxName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaxName.Text))
            {
                txtChargedTo.Clear();
                return;
            }
            txtChargedTo.Text = txtPaxName.Text;
        }

    }
}

