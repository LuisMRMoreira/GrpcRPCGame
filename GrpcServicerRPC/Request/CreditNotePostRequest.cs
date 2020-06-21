using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Models
{
    public class CreditNotePostRequest
    {
        public double amount { get; set; }
        public double userId { get; set; }

    }
}
