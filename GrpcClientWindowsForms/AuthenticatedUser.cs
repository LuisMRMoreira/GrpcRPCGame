using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms
{
    // Guarda os dados do utilizador que está autenticado na view
    class AuthenticatedUser
    {
        public string SessionID { get; private set; }
        public string Username { get; private set; }

        public AuthenticatedUser(string sessionID, string username)
        {
            SessionID = sessionID;
            Username = username;
        }
    }
}
