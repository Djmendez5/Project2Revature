using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Xrm.Sdk;

namespace Insurance_Website.Class_Files
{
    internal class Claim
    {
        public string Title { get; set; }
        //public string Title { get; set; }
        public string AccountNumber { get; set; }

        public Money Amount { get; set; }

        public Claim(string title, string accountNumber, string amount)
        {
            Title = title;
            AccountNumber = accountNumber;
            Amount = new Money(Convert.ToDecimal(amount));
        }
    }
}