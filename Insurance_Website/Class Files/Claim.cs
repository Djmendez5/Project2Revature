using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance_Website.Class_Files
{

    internal class Claim
    {
        public string Subject { get; set; }
        //public string Title { get; set; }
        public string PolicyNumber { get; set; }

        public decimal Amount { get; set; }

        public Claim(string subject, string policyNumber, string amount)
        {
            Subject = subject;
            PolicyNumber = policyNumber;
            Amount = Convert.ToDecimal(amount);
        }
    }

}