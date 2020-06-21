using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Models
{
    public class Transaction
    {
        public string idSender { get; set; }
        public string idReceiver { get; set; }
        public string date { get; set; }
        public double amount { get; set; }



    }
}
