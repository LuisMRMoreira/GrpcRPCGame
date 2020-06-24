using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServerRPS.APICommunication.Bodies
{
    public class ResponseValidTransactionPost
    {

        public string status { get; set; }
        public long currentAccountAmount { get; set; }
    }
}
