using GrpcClientConsoleApp.Models;
using GrpcClientWindowsForms.APICommunication.Bodies;
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
    // Estabelece a comunicação entre o cliente e a API.
    public abstract class APIClientCommunication
    {
        private static string BASE_URL = "http://localhost:8080/api/";
        private static HttpClient client = new HttpClient();

        // Obter uma conta (juntamente com as suas notas de crédito), a partir do id de sessão do utilizador desejado.
        public async static Task<Account> GetUserBySessionId(string sessionId)
        {
            var responseUser = client.GetStreamAsync(BASE_URL + "accounts/session/" + sessionId );
            //responseUser.EnsureSuccessStatusCode();

            var a = await JsonSerializer.DeserializeAsync<ResponseAccountGetBySessionId>(await responseUser);

            return a.data;
        }

        // Não utilizado: Obter todas as notas de crédito a partir de um id de sessão.
        public async static Task<List<CreditNote>> GetCreditNotesBySessionId(string sessionId)
        {

            HttpResponseMessage response = await client.GetAsync(BASE_URL + "accounts/"); // TODO: Get list of creditnotes by user id. Alterar o URL para o get das creditnotes do utilizador com o id outcome.UserId
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CreditNote>>(apiResponse);

        }

        // Obter todas as transações onde um utilizador referenciado por um id de sessão interveio.
        public async static Task<List<Transaction>> GetTransactionsBySessionId(string sessionId)
        {
            var response = client.GetStreamAsync(BASE_URL + "transactions/" + sessionId);
            

            var a = await JsonSerializer.DeserializeAsync<ResponseTransactions>( await response);
            return a.data;
        }

        // Criar nota de crédito
        public async static Task<ResponseCreditNotePost> PostCreateCreditNote(float amount, string sessionId)
        {
            String json = "{\n\"sessionId\": \"" + sessionId + "\",\n\"amount\":" + amount + "\n}";
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes", stringContent);
            //response.EnsureSuccessStatusCode();
            
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseCreditNotePost>(apiResponse);
        }


    }
}
