using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientConsoleApp.Models
{
    public class CreditNote
    {

        public string idAccount { get; set; }
        public long reference { get; set; }
        public double amount { get; set; }
        public string dateCreation { get; set; }
        public string dateExpiry { get; set; }
        public Boolean used { get; set; }


    }
}
