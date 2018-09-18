using System;
using System.Windows.Forms;
using ccMonitoringApp.dlls;

namespace ccMonitoringApp
{
    public partial class frmLogin : Form
    {
        private clsLoginData _LoginData = new clsLoginData();
        public int userID;
        public string isLogged;


        public frmLogin()
        {
            InitializeComponent();
        }


        private void commandClick(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;

            try
            {
                if (btnClicked.Name.ToString().Equals("btnLogin"))
                {
                    userID = _LoginData.getUserID(txtUserName.Text, txtPassword.Text);

                    if (userID == -1)
                    {

                        MessageBox.Show("Invalid user name / password", ":: Error :: ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.DialogResult = DialogResult.No;
                    }
                    else
                    {
                        if (_LoginData.changedPass)
                        {
                            frmNewPassword _Password = new frmNewPassword();

                            while  (_Password.ShowDialog() != DialogResult.OK)
                            {
                                _Password.ShowDialog();
                            }

                            string newPassword = _Password.newUserPassword;
                            _LoginData.updatePassword(userID, newPassword);

                            _Password.Close();

                            MessageBox.Show("Password UPDATED",":: CC MONITORING APP ::", MessageBoxButtons.OK);
                        }

                        this.DialogResult = DialogResult.Yes;
                        isLogged = _LoginData.LoggedUser;

                        this.Close();
                    }
                    return;
                }


                if (btnClicked.Name.ToString().Equals("btnCnclLogin"))
                {
                    this.Close();
                    Application.Exit();
                    return;
                }

            }
            catch (Exception ex)
            {
                if (_LoginData.isError)
                {
                    MessageBox.Show(_LoginData._error, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //this.Text = ":: " + Properties.Settings.Default.CompanyName + " ::";
            try
            {
                _LoginData.makeConnection();
            }
            catch (Exception ex)
            {
                if (_LoginData.isError)
                {
                    MessageBox.Show(_LoginData._error, ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

        }
    }
}
