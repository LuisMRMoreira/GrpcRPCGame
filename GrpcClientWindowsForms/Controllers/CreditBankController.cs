using GrpcClientConsoleApp.Models;
using GrpcClientWindowsForms.Models;
using GrpcServerRPS;
using GrpcServerRPS.APICommunication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GrpcClientWindowsForms.Controllers
{
    class CreditBankController
    {

        public static User.UserClient AuthClient { get; private set; }
        public static Game.GameClient GameClient { get; private set; }


        public CreditBankController()
        {
            // Events
            Program.CreditBankMenurView.APICreateCredinote += CreditBankMenurView_APICreateCredinote;
            Program.CreditBankMenurView.APIGetDataOnLoadRequest += CreditBankMenurView_APIGetDataOnLoadRequest;
            Program.AuthView.APIValidateReference += AuthView_APIValidateReference;
             
        }

        private async void AuthView_APIValidateReference(string reference)
        {

            ValidadeReferenceModel outcome = null;

            try
            {
                ValidadeReferenceLookuoModel transactionData = new ValidadeReferenceLookuoModel
                {
                    SessionId = Program.AuthUser.SessionID,
                    Reference = reference
                };

                outcome = await GameClient.ValidadeReferenceAsync(transactionData);

            }
            // No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            catch (Grpc.Core.RpcException)
            {
                Program.ConnectController.ConnectionError();
                return;
            }


            if (outcome.IsItValid == 1 && outcome != null) // Referencia introduzida válida.
            {
                Program.AuthView.ValidateReference();
            }
            else // Referencia introduzida inválida.
            {
                Program.AuthView.InvalidateReference();
            }
        }

        // Popular a view CreditBantMenuView com os dados referentes ao utilizador logado.
        private async void CreditBankMenurView_APIGetDataOnLoadRequest(int typeOfData)
        {
            //UserIdByUserSessionIdModel outcome = null;

            //try
            //{
            //    UserIdByUserSessionIdLookupModel userIdRequest = new UserIdByUserSessionIdLookupModel
            //    {
            //        SessionID = Program.AuthUser.SessionID,
            //        Username = Program.AuthUser.Username
            //    };

            //    outcome = await AuthClient.UserIdByUserSessionIdAsync(userIdRequest);

            //}
            //// No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            //catch (Grpc.Core.RpcException)
            //{
            //    Program.ConnectController.ConnectionError();
            //    return;
            //}



            //if (outcome.UserId != -1)
            //{

            //}
            //else
            //{

            //    // TODO: Mostrar erro ao tentar encontrar o id sessão no servidor.

            //}

            switch (typeOfData)
            {
                case 1: // Username

                    Program.CreditBankMenurView.PopulateUserData(await APIClientCommunication.GetUserBySessionId(Program.AuthUser.SessionID));

                    break;
                case 2: // Credit notes by user

                    //getCreditnotes();

                    break;
                case 3: // Historic

                    Program.CreditBankMenurView.PopulateHistoricTable(await APIClientCommunication.GetTransactionsBySessionId(Program.AuthUser.SessionID));

                    break;            
            }
            
        }

        private async void getCreditnotes()
        {

            // enviar para a view do menu do banco de créditos para que possa apresentar todas as credirnotes numa lista
            //Program.CreditBankMenurView.PopulateCreditNoteTable(await APIClientCommunication.GetCreditNotesBySessionId(Program.AuthUser.SessionID));

        }


        // Criar creditnote
        private async void CreditBankMenurView_APICreateCredinote(float amount)
        { 

            //// Obter o id do utilizador a paritr do id de sessao
            //UserIdByUserSessionIdModel outcome = null;

            //try
            //{
            //    UserIdByUserSessionIdLookupModel userIdRequest = new UserIdByUserSessionIdLookupModel
            //    {
            //        SessionID = Program.AuthUser.SessionID,
            //        Username = Program.AuthUser.Username
            //    };

            //    outcome = await AuthClient.UserIdByUserSessionIdAsync(userIdRequest);

            //}
            //// No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            //catch (Grpc.Core.RpcException)
            //{
            //    Program.ConnectController.ConnectionError();
            //    return;
            //}


            // enviar para a view do menu do banco de créditos para que possa apresentar todas as credirnotes numa lista
            Program.CreditBankMenurView.AddCreditNoteRowToTable(await APIClientCommunication.PostCreateCreditNote(amount, Program.AuthUser.SessionID));

        }


    }
}
