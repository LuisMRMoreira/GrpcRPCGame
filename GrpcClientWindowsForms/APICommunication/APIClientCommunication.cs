using GrpcClientConsoleApp.Models;
using GrpcClientWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcServerRPS.APICommunication
{
    // Gere a comunicação com o servidor e com a API.
    public abstract class APIClientCommunication
    {

        private static string BASE_URL = "http://localhost:8080/";
        private static HttpClient client = new HttpClient();

        public async static Task<Boolean> validateReference( string transaction ) {


            HttpResponseMessage response = await client.GetAsync(BASE_URL + "accounts/"); // TODO: Verificar se existe a referencia. Caso exista. Faz a transferencia para o servidor e invalida a creditnote.
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Boolean>(apiResponse);


        }

        
        public async static Task<Account> GetUserBySessionId(string sessionId)
        {
            HttpResponseMessage responseUser = await client.GetAsync(BASE_URL + "accounts/"); // TODO: Get all the information of the user by user session id 
            responseUser.EnsureSuccessStatusCode();

            string apiResponseUser = await responseUser.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Account>(apiResponseUser);

        }


        public async static Task<List<CreditNote>> GetCreditNotesBySessionId(string sessionId)
        {

            HttpResponseMessage response = await client.GetAsync( BASE_URL + "accounts/"); // TODO: Get list of creditnotes by user id. Alterar o URL para o get das creditnotes do utilizador com o id outcome.UserId
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CreditNote>>(apiResponse);

        }

        public async static Task<List<Transaction>> GetTransactionsBySessionId(string sessionId)
        {

            HttpResponseMessage response = await client.GetAsync(BASE_URL + "accounts/"); // TODO: Get list of creditnotes by user id. Alterar o URL para o get das creditnotes do utilizador com o id outcome.UserId
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Transaction>>(apiResponse);

        }


        public async static Task<CreditNote> PostCreateCreditNote(float amount, string sessionId)
        {

            // Criar credit note na API
            CreditNotePostRequest creditNotePostRequest = new CreditNotePostRequest
            {
                amount = amount,
                userId = sessionId
            };

            var myContent = JsonSerializer.Serialize(creditNotePostRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            HttpResponseMessage response = await client.PostAsync(BASE_URL + "accounts/", byteContent); // TODO: Pedido para criar uma nova creditnote para o utilizador atual, com o valor x.
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CreditNote>(apiResponse);

        }


    }
}
