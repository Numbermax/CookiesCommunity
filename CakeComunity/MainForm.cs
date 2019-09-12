using CakeComunity.Entities;
using CakeComunity.Logic;
using CakeComunity.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CakeComunity
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateBalances();
            UpdatePurchases();
            //var employees = new EmployeeRepository().GetAll().ToArray();            
            comboBox1.DataSource = new EmployeeRepository().GetAll().ToArray();
            comboBox2.DataSource = new EmployeeRepository().GetAll().ToArray();
            comboBox3.DataSource = new EmployeeRepository().GetAll().ToArray();
            FullName.Text = Autorisation.GetName();
            textBox1.Text = Autorisation.GetAutirisationDate();
            checkBox1.Checked = Autorisation.IsActive();
            if (!Autorisation.IsAdmin())
            {
                tabControl1.TabPages.Remove(Operations);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(costInput.Text, out float costValue))
            {
                Operations operations = new Operations();
                Employee employee = (Employee)comboBox1.SelectedItem;
                if (!operations.AddPurchase(employee, costValue, purchaseInput.Text))
                {
                    MessageBox.Show("Check parametres");
                    return;
                }
            }
            UpdateBalances();
            UpdatePurchases();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            if (float.TryParse(summInput.Text, out float parsedSumm))
            {
                Employee payer = (Employee)comboBox2.SelectedItem;
                Employee employee = (Employee)comboBox3.SelectedItem;
                Operations operations = new Operations();
                if (!operations.AddPayment(payer.WalletGuid, employee.WalletGuid, parsedSumm))
                {
                    MessageBox.Show("Error! Check parameters");
                    return;
                }
            }
            UpdateBalances();
            UpdatePurchases();

        }
        
        private void UpdateBalances()
        {
            TransactRepository transacts = new TransactRepository();
            var balances = Autorisation.IsAdmin()
                ? transacts.GetBalancesAll() 
                : transacts.GetBalancesByGuid(Autorisation.GetUserWalletGuid());

            listView1.Items.Clear();

            foreach (Balance balance in balances)
            {
                var row = new string[]
                {
                    balance.FullNameDebtor,
                    balance.Amount.ToString(),
                    balance.FullNameCreditor

                };
                var lv = new ListViewItem(row)
                {
                    Tag = balance
                };
                listView1.Items.Add(lv);
            }
        }
        private void UpdatePurchases()
        {
            var purchases = new PurchaseRepository().GetAll();
            EmployeeRepository employees = new EmployeeRepository();

            listView2.Items.Clear();

            foreach (Purchase purchase in purchases)
            {
                var row = new string[]
                {
                    employees.GetById(purchase.EmployeeId).ToString(),
                    purchase.Comment,
                    purchase.Cost.ToString(),
                    purchase.CountEmployees.ToString(),
                    purchase.CreateDate.ToString("dd.MM.yyyy")

                };
                var lv = new ListViewItem(row)
                {
                    Tag = purchase
                };
                listView2.Items.Add(lv);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Autorisation.SetActive(checkBox1.Checked);
        }
    }
}
