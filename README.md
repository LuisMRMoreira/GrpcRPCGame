# GrpcRPCGame
Implementação do jogo Pedra-Papel-Tesoura, com auxilio à tecnologia de comunicação entre cliente e servidor, gRPC.

De forma a armazenar os dados dos utilizadores, foi criada uma base de dados com auxilio à Entity Framework.

Para que a base de dados seja criada corretamente, tem de se aplicar as migrações:
- update database.

Tutorial de integração da Entity Framework num projeto com gRPC: https://www.youtube.com/watch?v=Xh47x_C-aMM

Tutorial de implementação de um sistema gRPC: https://www.youtube.com/watch?v=QyxCX2GYHxk

O cliente é um projeto do tipo Console Application (.Net core) (No futuro: Windows Froms App (.Net core)) e o servidor é um projeto gRPC service.

Para adicionar um projeto existente a um repositório já criado no gitHub, no visual studio clica-se em File> Add to source control > Team explorer
