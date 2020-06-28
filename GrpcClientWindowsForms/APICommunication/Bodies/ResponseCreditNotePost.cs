using GrpcClientConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Models
{
    public class ResponseCreditNotePost
    {
        public string status { get; set; }
        public CreditNote data { get; set; }
    }
}
