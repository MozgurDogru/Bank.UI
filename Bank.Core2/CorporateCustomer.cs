using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core2
{
    public class CorporateCustomer : Customer
    {
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Contact { get; set; }


        public override string ToString()
        {
            return this.CustomerNumber + "-" + this.Name.ToUpper();
        }

        public override string SentMoney(double amount, Customer buyer)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                buyer.Balance += amount;
                return "İşlem Tamam!\nYeni Bakiye:" + this.Balance;
            }
            else
            {
                return "Bakiye Yetersiz!\n" + this.Balance;
            }
        }


    }
}
