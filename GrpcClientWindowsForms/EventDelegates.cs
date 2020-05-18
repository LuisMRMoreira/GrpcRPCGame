using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms
{
    public delegate void ConnectRequest(string address);
    public delegate void LoginRequest(string username, string password);
    public delegate void PlayRequest(int play);
    public delegate void SimpleRequest();
    public delegate void RegisterRequest(string username, string email, string password, string passwordConfirmation);
}
