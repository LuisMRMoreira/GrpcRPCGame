using GrpcClientConsoleApp.Models;
using GrpcClientWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcServerRPS.APICommunication
{
    // Gere a comunicação com o servidor e com a API.
    public abstract class APIClientCommunication
    {

        private static string BASE_URL = "http://localhost:8080/api/";
        private static HttpClient client = new HttpClient();



        // Testado -> Funciona
        public async static Task<Account> GetUserBySessionId(string sessionId)
        {
            var responseUser = client.GetStreamAsync(BASE_URL + "accounts/session/" + sessionId ); // TODO: Get all the information of the user by user session id 
            //responseUser.EnsureSuccessStatusCode();

            //string apiResponseUser = await responseUser.Content.ReadAsStringAsync();
            var a = await JsonSerializer.DeserializeAsync<ResponseAccountGetBySessionId>(await responseUser);

            


            return a.data;

        }


        public async static Task<List<CreditNote>> GetCreditNotesBySessionId(string sessionId)
        {

            HttpResponseMessage response = await client.GetAsync(BASE_URL + "accounts/"); // TODO: Get list of creditnotes by user id. Alterar o URL para o get das creditnotes do utilizador com o id outcome.UserId
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

        // Testado -> Funciona
        public async static Task<CreditNote> PostCreateCreditNote(float amount, string sessionId)
        {

            // Criar credit note na API
            //CreditNotePostRequest creditNotePostRequest = new CreditNotePostRequest
            //{
            //    amount = amount,
            //    userId = sessionId
            //};
            //var myContent = JsonSerializer.Serialize(creditNotePostRequest);


            String json = "{\n\"sessionId\": \"" + sessionId + "\",\n\"amount\":" + amount + "\n}";
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes", stringContent); // TODO: Pedido para criar uma nova creditnote para o utilizador atual, com o valor x.
            response.EnsureSuccessStatusCode();
            
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseCreditNotePost>(apiResponse).data;

        }


    }
}
