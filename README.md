# Template-NetCoreApi-DDD

## Arquitetura do Projeto

Os respectivos projetos foram criados utilizando .Net Core 2.2.

### Camadas
- Application: camada responsável pelo projeto principal da API, onde terão os métodos expostos para serem consumidos via requisições HTTP e direcionar para os serviços responsáveis;
- Domain: responsável pela implementação das classes, modelos, interfaces, enums, DTO, etc;
- Service: "coração" do projeto, onde toda regra de negócio/validação é aplicada para os respectivos métodos de cada serviço antes da persistência os dados;
- Infrastructure: nesse respectivo projeto, realiza apenas a persitência com o banco de dados utilizando Entity Framework Core como persistência (abordagem code first/migrations);
- Testing: camada que realiza os testes unitários utilizando XUnit.

Obs.: autenticação do controlador principal (TransactionsController) que realiza os métodos solicitados no requisito utilizando BasicAuthentication.
