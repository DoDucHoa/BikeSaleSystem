using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeSaleSystemUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCloseSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
            MainFrame frm = new MainFrame();
            frm.Show();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsernameSU.Text;
            string password = txtPasswordSU.Text;
            
            
            
            string re_password = txtReEnterPW.Text;
            string fullname = txtFullName.Text;

            if (password.Equals(re_password))
            {
                if (chkCheckBox.Checked)
                {
                    UserDAO.createUser(username, re_password, fullname);
                    MessageBox.Show("Sign up success.", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                    MainFrame frm = new MainFrame();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Please agree terms to sign up.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Re-Enter Password is incorrect", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReEnterPW.Focus();
            }
        }
    }
}
