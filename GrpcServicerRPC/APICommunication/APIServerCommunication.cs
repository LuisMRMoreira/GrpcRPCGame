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
    // Estabelece a comunicação entre o servidor e com a API.
    public abstract class APIServerCommunication
    {

        private static string BASE_URL = "http://localhost:8080/api/";
        private static HttpClient client = new HttpClient();

        public static void reset() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        // Sempre o utilizador faz login, o id de sessão é alterado. De forma a manter a consistência dos dados entre o cliente, servidor e API, o id de sessão do utilizador atual também tem de ser atualizado. Para além de se manter a consistência dos dados, permite que o cliente faça pedidos diretos à API.
        public async static Task UserLogin(string sessionId, long userId)
        {
            reset();
            String json = "{\n\"accountNumber\": " + userId.ToString() + ",\n\"sessionId\": \"" + sessionId + "\"\n}";
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL+ "accounts/session", stringContent);
            response.EnsureSuccessStatusCode();

        }

        // Registo de um novo servidor na API.
        public async static Task RegisterUser(string username, long userId)
        {
            reset();
            String json = "{\n\"name\": \"" + username + "\",\n\"accountNumber\": " + userId.ToString() + ",\n\"amount\": " + "500" + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "accounts", data);
            response.EnsureSuccessStatusCode();

        }

        // Validação da referência na API introduzida pelo cliente.
        public async static Task<ResponseValidateReference> validateReference(string reference, long accountNumber)
        {

            String json = "{\n\"reference\": " + reference + ",\n\"accountNumber\": " + accountNumber + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes/validate", data);
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseValidateReference>(apiResponse);


        }

        // No caso da referencia ser válida, é executada uma transação do valor da referencia indicada, para a conta do servidor.
        internal async static Task<String> transactionToServerByAccountId(int id, string reference)
        {
            String json = "{\n\"reference\": " + reference + ",\n\"accountNumber\": " + id + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes/use", data);
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return apiResponse;
        }


        // No caso do cliente vencer um jogo, é executada uma transação do servidor para o cliente.
        internal async static Task<String> transactionFromServerToClient(int userId, int amount)
        {
            String json = "{\n\"accountNumberSender\": " + "0" + ",\n\"accountNumberReceiver\": " + userId + ",\n\"amount\":" + amount + "\n}";
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "transactions", data);
            //response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return apiResponse;
        }
    }
}
