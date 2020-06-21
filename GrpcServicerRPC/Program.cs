using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcClientWindowsForms.Models;
using GrpcServerRPS;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace GrpcServicerRPC
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            // TODO: armazenar localmente como variavel de ambiente o id da conta do servidor na API. O id deve ser encriptado


            // TODO: Sempre que o servidor for executado, verifica-se se a variável é "", nesse caso, envia-se um pedido para que o servidor cre uma conta na API (isto só acontece quando o servidor executar pela primeira vez)
                       
            // TODO: No caso da variavel de ambiente já ter um valor, o programa segue sem qualquer acesso à API.


            // Criar a conta do servidor
            //HttpClient client = new HttpClient();

            //string username = "servidor"; 

            //var myContent = JsonSerializer.Serialize(username);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            //var byteContent = new ByteArrayContent(buffer);

            //HttpResponseMessage response = await client.PostAsync("http://localhost:8080/accounts", byteContent); // TODO: Pedido para criar uma nova creditnote para o utilizador atual, com o valor x. Retonar a refeência do servidor caso já tenha sido ou não criado.

            //response.EnsureSuccessStatusCode();

        }



        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
