using System;
using System.Windows.Forms;
using ccMonitoringApp.dlls;

namespace ccMonitoringApp
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmLogin _login = new frmLogin();

            _login.ShowDialog();

            if (_login.DialogResult == DialogResult.Yes)
            {

                this.Top = Screen.PrimaryScreen.WorkingArea.Top + Properties.Settings.Default.Top;
                this.Left = Screen.PrimaryScreen.WorkingArea.Left + Properties.Settings.Default.Left;

                clsDBTrav.UserID = _login.userID;
                clsDBTrav.isLogged = _login.isLogged.ToUpper();
                lblUser.Text = clsDBTrav.isLogged;
                clsDBTrav.makeConnection();
            }
            else
            {
                _login.Dispose();
                this.Dispose();
            }



        }


        private void commandButtonAction(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;

            if (btnClick.Name.ToString() == "button1")
            {
                frmDataLog frmlog = new frmDataLog();
                frmlog.dbConnection = clsDBTrav.objConn;
                frmlog.ShowDialog();
            }

            if (btnClick.Name.ToString() == "button3")
            {
                Application.Exit();
            }

            if (btnClick.Name.ToString() == "button2")
            {
                frmSearchParam frmSchPrm = new frmSearchParam();
                frmSchPrm.dbConnection = clsDBTrav.objConn;

                frmSchPrm.ShowDialog();
            }

        }
    }
}
