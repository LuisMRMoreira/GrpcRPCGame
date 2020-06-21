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
        public int state { get; set; }



    }
}
