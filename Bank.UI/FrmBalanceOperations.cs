using Bank.Core2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.UI
{
    public partial class FrmBalanceOperations : Form
    {
        Customer SENDER, BUYER;
        OperationType OPERATION;

        public delegate void MyeventHandler(Customer customer);
        public event MyeventHandler RefreshBalance;

        public FrmBalanceOperations(Customer selected, OperationType opr)
        {
            InitializeComponent();
            SENDER = selected;
            OPERATION = opr;
        }

        public FrmBalanceOperations(Customer senderCustomer, Customer buyerCustomer)
        {
            InitializeComponent();
            SENDER = senderCustomer;
            BUYER = buyerCustomer;
            OPERATION = OperationType.EFT;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(txtAmount.Text);
            switch (OPERATION)
            {
                case OperationType.GetMoney: MessageBox.Show(SENDER.GetMoney(amount)); break;
                case OperationType.PutMoney:
                    MessageBox.Show(SENDER.PutMoney(amount));
                    break;

                case OperationType.EFT:
                    MessageBox.Show(SENDER.SentMoney(amount, BUYER));
                    break;
            }
            RefreshBalance(SENDER);
            this.Close();
        }

        private void FrmBalanceOperations_Load(object sender, EventArgs e)
        {
            switch (OPERATION)
            {

                case OperationType.GetMoney:
                    lblMessage.Text = "Çekilecek tutar:";
                    break;

                case OperationType.PutMoney:
                    lblMessage.Text = "Yatırılacak tutar:";

                    break;

                case OperationType.EFT:
                    lblMessage.Text = "Havale  tutarı:";

                    break;




            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
