# GrpcRPCGame
Implementação do jogo Pedra-Papel-Tesoura, com auxilio à tecnologia de comunicação entre cliente e servidor, gRPC.

De forma a armazenar os dados dos utilizadores, foi criada uma base de dados com auxilio à Entity Framework.

Para que a base de dados seja criada corretamente, tem de se aplicar as migrações:
- update database.

Tutorial de integração da Entity Framework num projeto com gRPC: https://www.youtube.com/watch?v=Xh47x_C-aMM

Tutorial de implementação de um sistema gRPC: https://www.youtube.com/watch?v=QyxCX2GYHxk

O cliente é um projeto do tipo Console Application (.Net core) (No futuro: Windows Froms App (.Net core)) e o servidor é um projeto gRPC service.

Para adicionar um projeto existente a um repositório já criado no gitHub, no visual studio clica-se em File> Add to source control > Team explorer

*********************************************************************************************************
                                                      Nova versão
*********************************************************************************************************

Criação de sistema de crétidos com Node.js. Os utilizadores, para jograrem, têm de pedir ao sistema de créditos um certo número de créditos para que depois o apresente ao servidor. O servidor, tem de validar essa forma de pagamento. Isto é tudo feito através de uma API rest desenvolvida em Node.js, com uma base de dados criada em mongoDB.

- [Criar base de dados local, em mongoDB;](https://www.youtube.com/watch?v=wM7NJtQ0F6U)
- A base de dados foi criada online através da plataforma [MongoDb Atlas](https://account.mongodb.com/account/login?signedOut=true). Com base no [tutorial](https://www.youtube.com/watch?v=KKyag6t98g8). A conexão foi feita como a descrita na ponto abaixo;
- [Criar API rest em Node.js (adicionar conexão a uma base de dados mongoDB online)](https://www.youtube.com/watch?v=vjf774RKrLc);
- Acesso a uma API através da Framework .Net core. Através da classe [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.1) é possível aceder à API criada. [Tutorial](https://www.yogihosting.com/aspnet-core-consume-api/).


**JSON Schema noções:**
- [Mongoose: Schema types](https://mongoosejs.com/docs/4.x/docs/schematypes.html);
- [Mongoose: Schema geral](https://mongoosejs.com/docs/guide.html);
- [Schema geral](https://json-schema.org/understanding-json-schema/).
