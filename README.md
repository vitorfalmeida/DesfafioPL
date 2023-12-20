# Desafio Backend PL

Este projeto é uma API construída com .NET 6 e utiliza SQL Server como banco de dados.

## Configuração do Banco de Dados

Para configurar o banco de dados com Docker, siga estas etapas:

1. Crie um arquivo `.env` na raiz do projeto.
2. Adicione a seguinte linha ao arquivo, substituindo `YourStrong!Passw0rd` por uma senha segura de sua escolha:
SA_PASSWORD=YourStrong!Passw0rd
3. Para iniciar o banco de dados, execute o seguinte comando no terminal:
docker-compose up db
4. Certifique-se de não cometer o arquivo `.env` ao repositório. Adicione `.env` ao seu `.gitignore`.

## Conectar-se ao Banco de Dados

Você pode se conectar ao banco de dados SQL Server em execução no Docker usando a porta padrão `1433`. Use suas ferramentas de gerenciamento de banco de dados preferidas, como o SQL Server Management Studio ou o Azure Data Studio, para se conectar ao banco de dados usando a seguinte string de conexão:
Server=localhost,1433;Database=meubanco;User Id=sa;Password=YourStrong!Passw0rd;
Substitua `YourStrong!Passw0rd` pela senha que você definiu no arquivo `.env`.

## Usando o Entity Framework Core Migrations 
Para gerenciar o esquema do banco de dados, este projeto utiliza migrações do Entity Framework Core. 
Siga estes passos para aplicar migrações ao banco de dados:

1.Gere a Migração Inicial (se ainda não tiver feito) com o comando:
dotnet ef migrations add InitialCreate
*Substitua InitialCreate por um nome descritivo para sua migração.
2.Aplique a Migração ao banco de dados com:
dotnet ef database update
Isso criará o banco de dados "meubanco" e aplicará o esquema definido nas migrações.
