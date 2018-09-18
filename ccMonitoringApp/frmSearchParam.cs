using System;
using System.Windows.Forms;
using ccMonitoringApp.dlls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace ccMonitoringApp
{
    public partial class frmSearchParam : Form
    {
        private clsDBTravData _TravData = new clsDBTravData();
        private string userlogged;

        public frmSearchParam()
        {
            InitializeComponent();
        }

        public SqlConnection dbConnection
        {
            get { return _TravData.dbConnection; }
            set { _TravData.dbConnection = value; }
        }

        private void commandButtonAction(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            string sqlStmt = "";

            if (btnClick.Name.ToString().Equals("btnSearch"))
            {
                if(chkAll.Checked == true)
                {
                    sqlStmt = clsDBValues.getTransData + "('','','')";

                    _TravData.getDataTrav(sqlStmt, "tbl_CCtrans");

                    dgvCCData.DataSource =  _TravData.dsData.Tables[0];
                    //dgvCCData.DataMember = "tbl_CCtrans";

                    dgvCCData.Visible = true;

                }else if (((txtRefNumSrch.Text != "") ||  (txtRelocSrch.Text !="") || (txtPaxNameSrch.Text !="")) && chkAll.Checked == false)
                {
                    if (txtRefNumSrch.Text != "")
                    {
                        var newString = txtRefNumSrch.Text.PadLeft(10, '0');
                        txtRefNumSrch.Text = newString;
                    }

                    sqlStmt = clsDBValues.getTransData + "('" + txtRefNumSrch.Text + "','" + txtRelocSrch.Text + "','" + txtPaxNameSrch.Text + "')";

                    _TravData.getDataTrav(sqlStmt, "tbl_CCtrans");

                    dgvCCData.DataSource = _TravData.dsData.Tables[0];
                    //dgvCCData.DataMember = "tbl_CCtrans";

                    dgvCCData.Visible = true;

                }
                else
                {
                    MessageBox.Show("Please input Search Parameters", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            if (btnClick.Name.ToString().Equals("btnSelect"))
            {
                if (dgvCCData.SelectedRows.Count > 0)
                {
                    string stat = dgvCCData.Rows[dgvCCData.SelectedRows[0].Index].Cells["status"].Value.ToString();

                    if (stat != "CANCELLED")
                    {
                        string refNo = dgvCCData.Rows[dgvCCData.SelectedRows[0].Index].Cells["NumberCode"].Value.ToString();

                        sqlStmt = clsDBValues.cancelTransData + " EditedBy ='" + clsDBTrav.isLogged + "', EditedDate = GETDATE() where NumberCode ='" + refNo + "'";

                        var resp = MessageBox.Show("Are you sure you want to cancel this transaction?", ":: INFORMATION ::", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        if (resp == DialogResult.OK)
                        {
                            _TravData.getDataTrav(sqlStmt, "tbl_CCtrans");
                            _TravData = null;

                            MessageBox.Show("Record has been CANCELLED", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                    }else
                    {
                        MessageBox.Show("Record is already CANCELLED", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("Please select a record", ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
