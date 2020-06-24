using GrpcClientConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Models
{
    public class Account
    {
        public long accountNumber { get; set; }
        public string sessionId { get; set; }
        public double amount { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public Boolean disabled { get; set; }
        public List<CreditNote> notes { get; set; } 


    }
}
