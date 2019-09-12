using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CakeComunity.Logic;
using DbWorks;

namespace CakeComunity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ValidateSchema validate = new ValidateSchema();
            validate.Go();
        }

        private void ButLogin_Click(object sender, EventArgs e)
        {
            if (loginInput.Text == "" || passwordInput.Text == "")
            {
                MessageBox.Show("Login or password is empty");
                return;
            }
            Operations operations = new Operations();
            ;
            if (operations.LogIn(loginInput.Text, passwordInput.Text.GetHashCode()))
            {
                operations.LogIn(loginInput.Text, passwordInput.Text.GetHashCode());

                MainForm form = new MainForm
                {
                    Visible = true
                };
                this.Visible = false;

            }

        }

        private void SiginBut_Click(object sender, EventArgs e)
        {
            SigIn sig = new SigIn { Visible = true};
        }
    }
}
