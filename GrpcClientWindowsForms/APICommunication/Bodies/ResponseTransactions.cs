using GrpcClientWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.APICommunication.Bodies
{
    public class ResponseTransactions
    {
        public string status { get; set; }
        public List<Transaction> data { get; set; }

    }
}
