using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core2
{
    public class IndividiualCustomer : Customer
    {
        public string SurName { get; set; }
        public string Identity { get; set; }
        public string  MomSurname { get; set; }
        public DateTime  Birthday { get; set; }
        public override string ToString()
        {
            return this.CustomerNumber + "-" + this.Name.Substring(0,1).ToUpper()+this.Name.Substring(1).ToLower()+" "+this.SurName.ToUpper();
        }
    }
}
