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

        private static string BASE_URL = "http://localhost:8080/";
        private static HttpClient client = new HttpClient();


        // Login user.
        public async static Task UserLogin(string sessionId, long userId)
        {

            String json = "{\"sessionId\": \"" + sessionId + "\",\n\"userId\":\"" + userId + "\"}";
            var myContent = JsonSerializer.Serialize(json);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage response = await client.PostAsync(BASE_URL+ "accounts/", byteContent); // TODO: Pedido para alterar o id de sessão da conta através do id de utilizador.
            response.EnsureSuccessStatusCode();

        }

        // Servidor
        public async static Task RegisterUser(string username, long userId)
        {
            // Criar uma conta do utilizador no banco de creditos atraves da API
            String json = "{\"username\": \"" + username + "\",\n\"userId\":\"" + userId.ToString() + "\"}";
            var myContent = JsonSerializer.Serialize(json);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage response = await client.PostAsync(BASE_URL + "accounts/", byteContent); // TODO: Pedido para criar uma nova conta no sistema de creditos.
            response.EnsureSuccessStatusCode();

        }

    }
}
