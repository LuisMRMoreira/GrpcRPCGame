using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Models
{
    public class Transaction
    {
        public Account idSender { get; set; }
        public Account idReceiver { get; set; }
        public string date { get; set; }
        public int amount { get; set; }



    }
}
