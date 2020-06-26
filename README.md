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

Criação de sistema de crétido: Evolução da aplicação desenvolvida anteriormente (Comunicação simples com base na ferramente gRPC), acrescentando o acesso a uma API restfull de um sistema de créditos desenvolvida em Node.js. Os utilizadores, para jograrem, têm de pedir ao sistema de créditos um certo número para que possam apresente ao servidor. O servidor, tem de validar essa forma de pagamento. Isto é tudo feito através de uma API rest desenvolvida em Node.js, com uma base de dados criada em mongoDB.

- [Criar base de dados local, em mongoDB;](https://www.youtube.com/watch?v=wM7NJtQ0F6U)
- A base de dados foi criada online através da plataforma [MongoDb Atlas](https://account.mongodb.com/account/login?signedOut=true). Com base no [tutorial](https://www.youtube.com/watch?v=KKyag6t98g8). A conexão foi feita como a descrita na ponto abaixo;
- [Criar API rest em Node.js (adicionar conexão a uma base de dados mongoDB online)](https://www.youtube.com/watch?v=vjf774RKrLc);
- Acesso a uma API através da Framework .Net core. Através da classe [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.1) é possível aceder à API criada. [Tutorial](https://www.yogihosting.com/aspnet-core-consume-api/).


**JSON Schema noções:**
- [Mongoose: Schema types](https://mongoosejs.com/docs/4.x/docs/schematypes.html);
- [Mongoose: Schema geral](https://mongoosejs.com/docs/guide.html);
- [Schema geral](https://json-schema.org/understanding-json-schema/).


Para testar a API foi utilizada a pataforma [Postman](https://www.postman.com/).


**Funcionamento da aplicação:**
- Quando um utilizador cria uma conta, esta é também criada numa API designada por serviço de créditos. Um utilizador inicia a conta com um montante pré-estabelecido (neste momento 500 créditos);
- Sempre que é feito o login do utilizador, o id de sessão também é alterado na API de forma a facilitar o acesso direto entre o cliente e a API;
- No caso do login ser bem sucedido, o utilizador encontrará um menu que no canto superior direito dirá o número de jogos que ainda pode jogar. Estes jogos foram anteriormente comprados;
- Para comprar jogos, tem de se clicar no botão "Buy games" onde aparecerá uma text box para que o cliente introduza uma referência válida. No caso da referência não ser válida (já ter sido utilizada ou não existir), aparecerá uma mensagem no canto superior esquerdo. Caso contrário, serão adicionados à conta do utilizador um número de jogos, de acordo com o valor da referência e da taxa aplicada (neste momento 1 crédito = 1 jogo);
- Para se criar uma referência, é necessário criar uma nota de crédito. Para isso clica-se no botão central "Credit note" que redirecionará o utilizador para a view do serviço de créditos. Para além da possibilidade do utilizador criar uma nota de crédito com o valor que quiser (desde que não passe o montante disponível), ao clicar no botão "create credit" serão também aqui apresentadas:
  - Todas as transações feitas, onde o utilizador atual interveio (A verde, recebeu o montante, a vermelho pagou);
  - Todas as notas de crédito que o utilizador já criou (Vermelho indicam as que já foram utilizadas e ver as que ainda podem ser usadas. Para o utilizador copiar a referência da nota de crédito que deseja basta selecionar uma das da lista e clicar ctrl+c);
  - O montante que o utilizador contém;
  - O nome do utilizador.
- Voltando ao menu principal, no caso do utilizador já ter comprado jogos e de não os ter gasto, a opção de jogar será disponível através do clique no botão "Play", que redirecionará o utilizador para a view de jogo;
- Por fim, a view de jogo, terá o histórico de jogos, assim como o número de jogos que o utilizador pode jogar e as opções de jogo. No caso do utilizador já não ter mais jogos disponíveis, ser-lhe-á apresentada uma mensagem. No caso do utilizador vencer um jogo contra o servidor, este último irá transferir um valor em créditos (atualmente 1 crédito) para a conta do utilizador que o superou.


**importante:** Devido ao facto de a base de dados da API ser online e a base de dados do servidor de jogo ser local, pode haver uma inconsistência de dados. Para se ter 100% a certeza que tudo corre bem, deve-se limpar todas as entradas na base de dados online sempre que se pretender criar uma nova conta. Uma opção melhor seria colocar a base de dados da API localmente.

**importante:** Verificar se a base de dados do servidor de jogo está atualizada.

A API referente ao serviço de créditos, foi desenvolvida em Nodejs (sendo a base de dados implementada de forma não relacional - MongoDb) e encontra-se [neste repositório](https://github.com/DanielGuedes147/Sistemas-Distribuidos-API).
