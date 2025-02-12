﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GrpcServerRPS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        public int GamesToPlay { get; set; } // Número total de jogos que o cliente pode joagar sem que tenha de comprar mais jogos com creditos.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Password { get; set; }

        // Para cada utilizador é usado um ID de sessão, que é gerado sempre que um utilizador se autentica, sendo único para
        // cada utilizador. Este ID é constituido com 20 carateres alfanúmericos. Este ID é depois enviado ao cliente, sendo
        // que este cliente vai usar este ID como identificador do utilizador, em cada pedido ao serviço GRPC. É usado um ID
        // de sessão aleatório em vez de o ID do utilizador, para diminuir a probabilidade de obtenção de um ID de autenticação
        // de contas de utilizadores através de pesquisas de força bruta
        [MaxLength(20)]
        public string SessionID { get; set; }

        [InverseProperty("User")]
        public virtual History History { get; set; }



        // Método usado para gerar um ID de sessão para o utilizador
        public void GenerateSessionID()
        {
            // Carateres que o ID de sessão pode conter
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            
            var stringChars = new char[20];

            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            SessionID = new string(stringChars);
        }
    }
}
