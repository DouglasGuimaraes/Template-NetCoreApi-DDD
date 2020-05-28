# Template-NetCoreApi-DDD

## PERGUNTAS


**1) EXPLIQUE COM SUAS PALAVRAS O QUE É DOMAIN DRIVEN DESIGN E SUA IMPORTÂNCIA
NA ESTRATÉGIA DE DESENVOLVIMENTO DE SOFTWARE.**

É uma abordagem arquitetural orientada ao domínio, ou seja, focada no negócio. 
Visa desenhar a arquitetura do domínio em sua totalidade, criando as segmentações necessárias (camadas) e diminuindo o acoplamento do software escrito.
Acredito que a grande importância dessa abordagem na estratégia para o desenvolvimento de um software seja o entendimento total do domínio.
Nessa abordagem, um software não é iniciado sem um entendimento completo do domínio antes, com suas respectivas necessidades, características e particularidades.
Também considero um ponto forte a divisão de responsabilidade em camadas do projeto, o que torna o acomplamento baixo facilitando diversas tarefas, como manutenção e inclusão de novas funcionalidades.


**2) EXPLIQUE COM SUAS PALAVRAS O QUE É E COMO FUNCIONA UMA ARQUITETURA BASEADA
EM MICROSERVICES. EXPLIQUE GANHOS COM ESTE MODELO E DESAFIOS EM SUA
IMPLEMENTAÇÃO.**

É uma arquitetura que segmenta sua camada de serviços de acordo com cada domínio. 
Para cada segmento do negócio ou produto você irá construir uma camada de serviço (geralmente APIs RESTful) responsável por manter o respectivo seguimento.
Essa modularização segrega as funcionalidades e conseguimos manter deploys independentes (forte ganho) além de que conseguimos construir APIs em tecnologias diferentes (se for necessário).

Como não existe bala de prata, essa arquitetura também é acompanhada de algumas dificuldades, como: 

- dificuldade de debug e testes pois dependemos de muitas camadas distintas para esse tipo de ação;
- o conhecimento do negócio e técnico fica muito distribuído o que pode ser um dificultador dependendo de sua equipe;
- esforço para operar maior, uma vez que você depende de N serviços simultâneos.

O DDD de certa forma vem para auxiliar nessas dificuldades, amenizando as dificuldades ponderadas acima.

**3) EXPLIQUE QUAL A DIFERENÇA ENTRE COMUNICAÇÃO SINCRONA E ASSINCRONA E QUAL O
MELHOR CENÁRIO PARA UTILIZAR UMA OU OUTRA.**

**Comunicação síncrona:** emissor e receptor devem estar em um estado de sincronia antes da operações e permanecer até o seu fim. 
Geralmente um software desenvolvido de forma síncrona pode gerar uma má experiência ao usuário final pois todas as operações que são executadas precisam finalizar para que a interface fique novamente liberado para uso.

Melhor cenário para uso:
- Quando se tem a necessidade de esperar que uma ou mais ações sejam realmente concluídas, quando existem dependências entre as ações e você precisa que uma seja finalizada para prosseguir com a outra. Esse tipo de operação costuma entregar uma má experiência de uso do software ao usuário final. 

**Comunicação assíncrona:** emissor e receptor não precisar estar nesse estado de sincronia pois o emissor vai enviando os pacotes que detém um bit (flag) especial no início e no fim do mesmo, fazendo com o que o receptor entenda o que foi realmente enviado.

Melhor cenário para uso:
- Quando você precisa que o tempo de resposta do seu software seja rápido, não ocasionando impedimentos em sua interface, ou seja: quando a experiência com o usuário final é um fator imprenscindível para o funcionamento do sotfware.

## Arquitetura do Projeto

Os respectivos projetos foram criados utilizando .Net Core 2.2.

### Camadas
- Application: camada responsável pelo projeto principal da API, onde terão os métodos expostos para serem consumidos via requisições HTTP e direcionar para os serviços responsáveis;
- Domain: responsável pela implementação das classes, modelos, interfaces, enums, DTO, etc;
- Service: "coração" do projeto, onde toda regra de negócio/validação é aplicada para os respectivos métodos de cada serviço antes da persistência os dados;
- Infrastructure: nesse respectivo projeto, realiza apenas a persitência com o banco de dados utilizando Entity Framework Core como persistência (abordagem code first/migrations);
- Testing: camada que realiza os testes unitários utilizando XUnit.
