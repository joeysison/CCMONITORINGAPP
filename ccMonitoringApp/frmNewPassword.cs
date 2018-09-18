using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccMonitoringApp
{
    public partial class frmNewPassword : Form
    {
        frmNewPassword _frmNewPass;
        public string newUserPassword;
        
        public frmNewPassword()
        {
            InitializeComponent();

            _frmNewPass = this;
        }
        
        private void btnOKPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("New PASSWORD DOES NOT MATCH. \nPlease input again.", ":: ERROR ::", MessageBoxButtons.OK);

            }else
            {
                newUserPassword = txtNewPassword.Text;
                this.DialogResult = DialogResult.OK;
            }


        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim().Length > 5 && txtConfirmPass.Text.Trim().Length > 5)
            {
                btnOKPassword.Enabled = true;
            }else
            {
                btnOKPassword.Enabled = false;
            }
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim().Length > 5 && txtConfirmPass.Text.Trim().Length > 5)
            {
                btnOKPassword.Enabled = true;
            }
            else
            {
                btnOKPassword.Enabled = false;
            }
        }
    }
}
