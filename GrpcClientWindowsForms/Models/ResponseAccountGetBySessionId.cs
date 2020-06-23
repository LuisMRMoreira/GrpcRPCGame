using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Models
{
    public class ResponseAccountGetBySessionId
    {
        public string status { get; set; }
        public Account data { get; set; }

    }
}
