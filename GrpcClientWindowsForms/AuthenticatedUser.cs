using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms
{
    class AuthenticatedUser
    {
        public int ID { get; private set; }
        public string Username { get; private set; }

        public AuthenticatedUser(int id, string username)
        {
            ID = id;
            Username = username;
        }
    }
}
