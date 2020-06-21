using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcServerRPS.APICommunication
{
    // Gere a comunicação com o servidor e com a API.
    public abstract class APIServerCommunication
    {

        private static string BASE_URL = "http://localhost:8080/api/";
        private static HttpClient client = new HttpClient();


        // Login user.
        public async static Task UserLogin(string sessionId, long userId)
        {

            String json = "{\"sessionId\": \"" + sessionId + "\"}";
            var myContent = JsonSerializer.Serialize(json);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage response = await client.PostAsync(BASE_URL+ "accounts/session/" + userId, byteContent); // TODO: Pedido para alterar o id de sessão da conta através do id de utilizador.
            response.EnsureSuccessStatusCode();

        }

        // Servidor
        public async static Task RegisterUser(string username, long userId)
        {
            // Criar uma conta do utilizador no banco de creditos atraves da API
            String json = "{\"name\": \"" + username + "\",\n\"accountNumber\":\"" + userId.ToString() + "\",\n\"amount\":\"" + "500" + "\"}";
            var myContent = JsonSerializer.Serialize(json);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "accounts", byteContent); // TODO: Pedido para criar uma nova conta no sistema de creditos.
            response.EnsureSuccessStatusCode();

        }

        public async static Task<Boolean> validateReference(string reference, long accountNumber)
        {

            String json = "{\"reference\": \"" + reference + "\",\n\"accountNumber\":\"" + accountNumber + "\"}";
            var myContent = JsonSerializer.Serialize(json);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "creditnotes/validate", byteContent); // TODO: Verificar se existe a referencia. Caso exista. Faz a transferencia para o servidor e invalida a creditnote.
            response.EnsureSuccessStatusCode();

            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Boolean>(apiResponse);


        }

    }
}
