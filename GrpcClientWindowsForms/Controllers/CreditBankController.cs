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
            // Eventos
            Program.AuthView.GRPCStartRequest += CreditBankMenurView_GRPCSTartRequest;
            Program.CreditBankMenurView.APICreateCredinote += CreditBankMenurView_APICreateCredinote;
            Program.CreditBankMenurView.APIGetDataOnLoadRequest += CreditBankMenurView_APIGetDataOnLoadRequest;
            Program.AuthView.APIValidateReference += AuthView_APIValidateReference;
             
        }

        // Inicialização do cliente gRPC referente ao jogo.
        private void CreditBankMenurView_GRPCSTartRequest()
        {
            // No caso de a conexão já ter sido inicializada, não necessita de fazer mais nenhuma operação
            if (GameClient != null)
            {
                return;
            }

            // É criado um client de autenticação
            GameClient = new Game.GameClient(Program.ConnectionChannel);
        }


        // Tratamento do evento de validação de referencia. Este evento foi chamado no AuthView.
        private async void AuthView_APIValidateReference(string reference)
        {

            ValidadeReferenceModel outcome = null;

            try
            {

                // Modelo com as informações do pedido para o servidor tratar.
                ValidadeReferenceLookuoModel transactionData = new ValidadeReferenceLookuoModel
                {
                    SessionId = Program.AuthUser.SessionID,
                    Reference = reference
                };

                // Pedido assincrono de validação da referência passada pelo servidor.
                outcome = await GameClient.ValidadeReferenceAsync(transactionData);

            }
            // No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            catch (Grpc.Core.RpcException)
            {
                Program.ConnectController.ConnectionError();
                return;
            }
            catch (JsonException jsonEx)
            {
                Program.CreditBankMenurView.ShowMessageBox("Unable to validate the reference in the API due to json parse exception:\n" + jsonEx + "\nCreditBankController: AuthView_APIValidateReference");
                return;
            }
            catch (ArgumentNullException nullEx)
            {
                Program.CreditBankMenurView.ShowMessageBox("Unable to validate the reference in the API due to null exception:\n" + nullEx + "\nCreditBankController: AuthView_APIValidateReference");
                return;
            }
            catch (HttpRequestException httpEx)
            {
                Program.CreditBankMenurView.ShowMessageBox("Unable to validate the reference in the API due to Http request exception:\n" + httpEx + "\nCreditBankController: AuthView_APIValidateReference");
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
            switch (typeOfData)
            {
                case 1: // Obtem a parir da api o utilizador atual (através da sessionId) juntamente com as notas de crédito.

                    try
                    {
                        Program.CreditBankMenurView.PopulateUserData(await APIClientCommunication.GetUserBySessionId(Program.AuthUser.SessionID));
                    }
                    catch (JsonException jsonEx)
                    {
                        Program.CreditBankMenurView.ShowMessageBox("Unable to load data (user and credit notes) from API due to json parse exception:\n"+ jsonEx + "\nCreditBankController: CreditBankMenurView_APIGetDataOnLoadRequest");
                        return;
                    }
                    catch (ArgumentNullException nullEx) 
                    {
                        Program.CreditBankMenurView.ShowMessageBox("Unable to load data (user and credit notes) from API due to null exception:\n" + nullEx + "\nCreditBankController: CreditBankMenurView_APIGetDataOnLoadRequest");
                        return;
                    }
                    catch (HttpRequestException httpEx) 
                    {
                        Program.CreditBankMenurView.ShowMessageBox("Unable to load data (user and credit notes) from API due to Http request exception:\n" + httpEx + "\nCreditBankController: CreditBankMenurView_APIGetDataOnLoadRequest");
                        return;
                    }


                    break;
                case 3: // Transações associadas ao utilizador atual.

                    try
                    {
                        Program.CreditBankMenurView.PopulateHistoricTable(await APIClientCommunication.GetTransactionsBySessionId(Program.AuthUser.SessionID));
                        
                    }
                    catch (JsonException jsonEx)
                    {
                        Program.CreditBankMenurView.ShowMessageBox("Unable to load data (transactions) from API due to json parse exception:\n" + jsonEx + "\nCreditBankController: CreditBankMenurView_APIGetDataOnLoadRequest");
                        return;
                    }
                    catch (ArgumentNullException nullEx)
                    {
                        Program.CreditBankMenurView.ShowMessageBox("Unable to load data (transactions) from API due to null exception:\n" + nullEx + "\nCreditBankController: CreditBankMenurView_APIGetDataOnLoadRequest");
                        return;
                    }
                    catch (HttpRequestException httpEx)
                    {
                        Program.CreditBankMenurView.ShowMessageBox("Unable to load data (transactions) from API due to Http request exception:\n" + httpEx + "\nCreditBankController: CreditBankMenurView_APIGetDataOnLoadRequest");
                        return;
                    }


                    break;            
            }
            
        }

        // Tratamento do evento de criação de uma nova nota de crédito vindo da CreditBankMenuView.
        private async void CreditBankMenurView_APICreateCredinote(float amount)
        {


            try
            {
                // Comunicação com a API, de forma a criar uma noca nota de crédito com o amount referido pelo cliente com o id de sessão atual.
                ResponseCreditNotePost rcnp = await APIClientCommunication.PostCreateCreditNote(amount, Program.AuthUser.SessionID);
                if (rcnp.status.Equals("error"))
                {
                    // No caso da resposta do pedido à API ser igual a "error", apresenta-se uma mensagem na view CreditBankMenurView a informar o sucedido.
                    Program.CreditBankMenurView.UnableToCreateCreditNote();
                }
                else
                {
                    // enviar para a view do menu do banco de créditos para que possa apresentar todas as credirnotes numa lista
                    Program.CreditBankMenurView.AddCreditNoteRowToTable(rcnp.data);
                }

            }
            catch (JsonException jsonEx)
            {
                Program.CreditBankMenurView.ShowMessageBox("Unable to create a credit note on API due to json parse exception:\n" + jsonEx + "\nCreditBankController: CreditBankMenurView_APICreateCredinote");
            }
            catch (ArgumentNullException nullEx)
            {
                Program.CreditBankMenurView.ShowMessageBox("Unable to create a credit note on API due to null exception:\n" + nullEx + "\nCreditBankController: CreditBankMenurView_APICreateCredinote");
            }
            catch (HttpRequestException httpEx)
            {
                Program.CreditBankMenurView.ShowMessageBox("Unable to create a credit note on API due to Http request exception:\n" + httpEx + "\nCreditBankController: CreditBankMenurView_APICreateCredinote");
            }


        }


    }
}
