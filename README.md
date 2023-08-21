[NEW VERSION HERE](https://github.com/gmessiasc/LAB-Clothing-Collection-Csharp)

# LABCC-Back-End

Aplicação para estudo desenvolvida durante o curso DevInHouse - turma Audaces. Trata-se de uma simulação de API Rest de um serviço web do setor de modas, onde é possivel gerenciar e fazer operações com: usuários, coleções e modelos de roupa.

- [Video de Apresentação do Projeto](https://drive.google.com/drive/folders/1PXS0Swgk3zV_UU9n9cF9ZqXFpZfXZR9W?usp=sharing)
- [Trello da aplicação](https://trello.com/invite/b/mKBgG416/ATTI3585936ef5ef89c622a9269152308c9066228D90/lab-clothing-collection-back-end)

## Indice
- [Estudo de Caso](estudo-de-caso)
- [Dependencias e Tecnologias](dependencias-e-tecnologias)
- [Como instalar](como-instalar)
- [Como usar](como-usar)
- [Melhorias a Fazer](melhorias-a-fazer)
## Estudo de caso:

- A <strong>LABFashion LTDA</strong>, empresa líder no segmento tecnológico para gestão de moda, está com um projeto novo intitulado LAB Clothing Collection, um software audacioso para gestão de coleções de moda no setor de vestuário. 

- Como a empresa é multinacional, a demanda é que os sistema seja desenhado de forma que possa escalar tanto em questão de performace, quanto também com o uso de boas práticas para permitir a manutenção de outros desenvolvedores no futuro.


## Dependências e Tecnologias.

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/)
- [.NET Core 8.0](https://dotnet.microsoft.com/pt-br/)
- [Entity Framework Core 8.0.0-preview.6.23329](https://learn.microsoft.com/en-us/ef/core/)
- [AutoMapper (12.0.1)](https://automapper.org/)
- [FluentValidation (11.5.2)](https://docs.fluentvalidation.net/en/latest/)
- [SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-2022)
- ShaperAnnotationsForDataTypes (biblioteca criada por mim apenas para fins de estudos e ajudar na criação da aplicação) ( [github](https://github.com/gmessiasc/SharperAnnotationsForDataType) )
- [Docker](https://www.docker.com/) (não obrigatório)

- A aplicação foi feita usando o Domain-Driven Design (DDD), separando as aplicações por camadas. Tambem foi utilizado o SOLID.
## Como instalar:

- Após baixar o projeto, você precisará criar um '.env' na pasta raíz.

- Use o .env.example como base, preenchendo os dad,os especificos que ele pede. Caso use o docker, o docker-compose gerará a imagem já com os dados inseridos no .env.

- Você pode colocar os dados do servidor do SQL Server diretamente também, mas, caso queira usar o docker, após fazer o .env, use o comando:

```bash
docker compose up -d
```

obs: Caso queira usar o docker, lembre-se de escolher uma senha que seja compatível com as regras de senha da imagem do SQL Server no docker.

- Isso fará a imagem do docker subir, com os devidos dados inseridos no .env. Além de já configurar a aplicação para acessá-lo.

- Espere a imagem subir completamente.

- Uma vez feito isso, você pode rodar a aplicação com sua ide favorita ou simplesmente usar o dotnet cli ao inserir o comando:

```bash
dotnet watch
```

- Com isso a aplicação vai rodar com o Hot Reload ativado e abrirá um swagger no seu navegador, muito provavelmente na url: http://localhost:5041/swagger/index.html

- Ela também vai executar dados iniciais no banco.

## Como usar

- Sendo uma Rest API, basta fazer uma requisição para seus endpoints. Fiz o esforço de deixar o Swagger detalhado explicando quais são as requisições possiveis, basta acessá-lo.

- Você pode usar um Postman ou Insomnia para acessar os endpoints, ou o próprio swagger para fazer as requisições.

## Melhorias a fazer:

- <strong>Implementar testes automáticos</strong>: Apesar da ideia inicial é que já nessa versão tivesse testes unitários, mas não foi possível implementar pelo tempo.

- <strong>Implementação de segurança</strong>: A ideia é utilizar algum serviço de SSO para autenticação e autorização da aplicação (como keycloak);

- <strong>Melhorar conceitos de SOLID e Clean Code</strong> Muito do código foi feito às pressas, muita coisa pode ser melhorada, como por exemplo, a injeção de dependência que está sendo feita diretamente pela instância. É preciso isolar mais as camadas através de interfaces.

- <strong>Transformar o sistema em reativo</strong> para que possa ser escalável. 
