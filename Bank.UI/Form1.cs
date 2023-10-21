using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank.Core2;

namespace Bank.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlcorparate.Location = pnlIndividual.Location;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            IndividiualCustomer customer1 = new IndividiualCustomer()
            {
                Address = "Karşıyaka",
                Balance = 10000,
                Birthday = DateTime.Parse("01/01/1995"),
                CustomerNumber = "125",
                Identity = "741852963",
                Mail = "Ali@mail.com",
                MomSurname = "Yılmaz",
                Name = "Ali",
                SurName = "Veli",
                Phone = "555 55 55"


            };
            lbxCustomers.Items.Add(customer1);
            cmbCustomers.Items.Add(customer1);

            CorporateCustomer customer2 = new CorporateCustomer()
            {
                Address = "Konak",
                Balance = 1500000,
                Contact = "Emre Koç",
                CustomerNumber = "326",
                Mail = "admin@koc.com",
                Name = "Koç Ltd.",
                Phone = "444 44 44",
                TaxNumber = "852258",
                TaxOffice = "İzmir"
            };
            lbxCustomers.Items.Add(customer2);
            cmbCustomers.Items.Add(customer2);


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void lbxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer customer = lbxCustomers.SelectedItem as Customer;
            if (customer == null)
            {
                return;
            }
            DisplayCustomer(customer);
        }

        private void DisplayCustomer(Customer customer)
        {
            if (customer is IndividiualCustomer)//Bireysel müşteri ise; 
            {
                IndividiualCustomer selected = (IndividiualCustomer)customer;
                txtIdentity.Text = selected.Identity;
                txtMomSurname.Text = selected.MomSurname;
                txtSurname.Text = selected.SurName;
                dtBirthday.Value = selected.Birthday;
                rbtnIndividual.Checked = true;
            }
            else //Kurumsal müşteri ise;
            {
                CorporateCustomer selected = (CorporateCustomer)customer;
                txtTaxNumber.Text = selected.TaxNumber;
                txtTaxOfficce.Text = selected.TaxOffice;
                txtContact.Text = selected.Contact;
                rbtnCorporate.Checked = true;
            }
            //ortak alanlar:
            txtAddress.Text = customer.Address;
            txtBalance.Text = customer.Balance.ToString();
            txtCustomerNumber.Text = customer.CustomerNumber;
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            txtMail.Text = customer.Mail;

            rbtnIndividual.Enabled = rbtnCorporate.Enabled = false;
        }

        private void rbtnIndividual_CheckedChanged(object sender, EventArgs e)
        {
            pnlcorparate.Visible = rbtnCorporate.Checked;
            pnlIndividual.Visible = rbtnIndividual.Checked;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();

        }

        private void ClearControls()
        {
            rbtnIndividual.Enabled = rbtnCorporate.Enabled = true;
            rbtnIndividual.Checked = true;
            pnlEFT.Visible = false;
            dtBirthday.Value = DateTime.Now;
            lbxCustomers.SelectedItem = cmbCustomers.SelectedItem = null;

            foreach (Control İtem in this.Controls)
            {
                if (İtem is TextBox)
                {
                    İtem.Text = string.Empty;
                }
                foreach (Control item in pnlIndividual.Controls)

                {
                    if (İtem is TextBox)
                    {
                        İtem.Text = string.Empty;
                    }
                }
                foreach (Control item in pnlcorparate.Controls)
                {
                    if (İtem is TextBox)
                    {
                        İtem.Text = string.Empty;
                    }

                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }

        private void SaveCustomer()
        {
            Customer customer;

            if (rbtnIndividual.Checked)
            {//object initialize
                customer = new IndividiualCustomer()
                {
                    Birthday = dtBirthday.Value,
                    Identity = txtIdentity.Text,
                    MomSurname = txtMomSurname.Text,
                    SurName = txtSurname.Text,
                };
            }
            else
            {//object initialize
                customer = new CorporateCustomer()
                {
                    TaxNumber = txtTaxNumber.Text,
                    TaxOffice = txtTaxOfficce.Text,
                    Contact = txtContact.Text,

                };
            }
            customer.Name = txtName.Text;
            customer.Address = txtAddress.Text;
            customer.CustomerNumber = txtCustomerNumber.Text;
            customer.Phone = txtPhone.Text;
            customer.Balance = double.Parse(txtBalance.Text);
            customer.Mail = txtMail.Text;

            lbxCustomers.Items.Add(customer);
            cmbCustomers.Items.Add(customer);

            ClearControls();

        }

        private void btnEFT_Click(object sender, EventArgs e)
        {
                pnlEFT.Visible = !pnlEFT.Visible;
        }

        private void btnGetMoney_Click(object sender, EventArgs e)
        {
            Customer selected=lbxCustomers.SelectedItem as  Customer;
            if (selected == null) 
            {
                MessageBox.Show("Müşteri Seçiniz..");
                return;

            }
            FrmBalanceOperations frm= new FrmBalanceOperations(selected,OperationType.GetMoney);
            frm.RefreshBalance += Frm_RefreshBalance;
            frm.ShowDialog();
        }

        private void Frm_RefreshBalance(Customer customer)
        {
            DisplayCustomer(customer);
        }
    

        private void btnPutMoney_Click(object sender, EventArgs e)
        {
            Customer selected = lbxCustomers.SelectedItem as Customer;
            if (selected == null)
            {
                MessageBox.Show("Müşteri Seçiniz..");
                return;

            }
            FrmBalanceOperations frm = new FrmBalanceOperations(selected, OperationType.PutMoney);

            frm.RefreshBalance += Frm_RefreshBalance;
            frm.ShowDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Customer senderCustomer = lbxCustomers.SelectedItem as Customer;
            Customer buyerCustomer = cmbCustomers.SelectedItem as Customer;

            if (senderCustomer == null)
            {
                MessageBox.Show("Gönderici-Müşteri Seçiniz..");
             return;

            }
            if (buyerCustomer == null)
            {
                MessageBox.Show("alıcı-Müşteri Seçiniz..");
                return;
            }
            if (buyerCustomer == senderCustomer)
            {
                MessageBox.Show("Gönderici/Alıcı-Müşteri aynı olamaz..");
                return;
            }
                FrmBalanceOperations frm = new FrmBalanceOperations(senderCustomer,buyerCustomer);

            frm.RefreshBalance += Frm_RefreshBalance; 
            frm.ShowDialog();
        }
    }
}
