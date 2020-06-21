using GrpcServerRPS;
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
    public delegate void APILoginRequest(string username, string password);
    public delegate void APIRegisterRequest(string username, string email, string password, string passwordConfirmation);
    public delegate void APICreateCredinoteRequest(float amount);
    public delegate void APIGetDataOnLoadRequest(int typeOfData);
    public delegate void APIValidateReference(string reference);
}
