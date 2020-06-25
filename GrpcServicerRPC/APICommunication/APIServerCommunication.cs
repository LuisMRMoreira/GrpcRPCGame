using GrpcServerRPS.APICommunication.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcServerRPS.APICommunication
{
    // Gere a comunicação com o servidor e com a API.
    public abstract class APIServerCommunication
    {

        private static string BASE_URL = "http://localhost:8080/api/";
        private static HttpClient client = new HttpClient();

        public static void reset() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        // Login user. Testado -> Funciona.
        public async static Task UserLogin(string sessionId, long userId)
        {

            reset();
            String json = "{\n\"accountNumber\": " + userId.ToString() + ",\n\"sessionId\": \"" + sessionId + "\"\n}";
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL+ "accounts/session", stringContent);
            response.EnsureSuccessStatusCode();

        }

        // Servidor: Testado -> Funciona
        public async static Task RegisterUser(string username, long userId)
        {
            reset();
            // Criar uma conta do utilizador no banco de creditos atraves da API
            String json = "{\n\"name\": \"" + username + "\",\n\"accountNumber\": " + userId.ToString() + ",\n\"amount\": " + "500" + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "accounts", data); // TODO: Pedido para criar uma nova conta no sistema de creditos.
            response.EnsureSuccessStatusCode();

        }

        // Servidor: Testado -> Funciona
        public async static Task<ResponseValidateReference> validateReference(string reference, long accountNumber)
        {

            String json = "{\n\"reference\": " + reference + ",\n\"accountNumber\": " + accountNumber + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes/validate", data); // TODO: Verificar se existe a referencia. Caso exista. Faz a transferencia para o servidor e invalida a creditnote.
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseValidateReference>(apiResponse);


        }

        // Servidor: Testado -> Funciona
        internal async static Task<String> transactionToServerByAccountId(int id, string reference)
        {
            String json = "{\n\"reference\": " + reference + ",\n\"accountNumber\": " + id + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes/use", data); // TODO: Verificar se existe a referencia. Caso exista. Faz a transferencia para o servidor e invalida a creditnote.
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return apiResponse;
        }


        // Servidor:
        internal async static Task<String> transactionFromServerToClient(int userId, int amount)
        {
            String json = "{\n\"accountNumberSender\": " + "0" + ",\n\"accountNumberReceiver\": " + userId + ",\n\"amount\":" + amount + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "transactions", data); // TODO: Verificar se existe a referencia. Caso exista. Faz a transferencia para o servidor e invalida a creditnote.
            //response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return apiResponse;
        }
    }
}
