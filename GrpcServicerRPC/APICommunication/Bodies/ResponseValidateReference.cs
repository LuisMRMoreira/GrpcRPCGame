using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServerRPS.APICommunication.Bodies
{
    public class ResponseValidateReference
    {
        public string status { get; set; }
        public string valid { get; set; }
    }
}
