using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core2
{
    public abstract class Customer
    {
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }
        public string Mail { get; set; }

        public string GetMoney(double amount)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                return "İşlem Tamam!\nYeni Bakiye:" + this.Balance;
            }
            else
            {
                return "Bakiye Yetersiz!\n" + this.Balance;
            }

        }
        public string PutMoney(double amount)
        {

            this.Balance += amount;
            return "İşlem Tamam!\nYeni Bakiye:" + this.Balance;
        }   
            public virtual string SentMoney(double amount,Customer buyer)
            {
                double cost = 50;
                if (this.Balance >= (amount+cost))
                {
                    this.Balance -= (amount + cost);
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
