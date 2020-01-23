# Plataforma Investimento
Desafio de Programação
## Pré-requisitos
- .Net Core 3.0: https://dotnet.microsoft.com/download/dotnet-core/3.0
- Entity Framework Core-CLI: dotnet tool install --global dotnet-ef --version 3.0.0 ou via Nuget
- Docker Toolbox: https://github.com/docker/toolbox/releases
- Node v10.16.3 (inclui npm): https://nodejs.org/en/download/
- Angular Cli 8.3.+ : execute 'npm install -g @angular/cli' no terminal
## Instalação
Depois de atender os Pré-requisitos:
- No terminal do Docker, execute `docker run -p 8080:8080 toroinvestimentos/quotesmock`
- Clone o repositório `git clone https://github.com/raviassis/plataforma_investimento.git`
- Acesse o diretório `cd plataforma_investimento`
- Execute as Migrações `dotnet ef database update --project='.\InvestimentoApi\InvestimentoApi\'`;
- Execute o Job de integração com o Mock de cotações `dotnet run --project='.\InvestimentoApi\Investimento.WebJob\'`
- Execute a api `dotnet run --project='.\InvestimentoApi\InvestimentoApi\'`
- Acesse o caminho do projeto do Frontend `cd plataforma_investimento/InvestimentoClient`
- Instale as dependências: npm install
- Execute o projeto do front: ng serve -o

Seguido esses passos o projeto estará pronto para uso.

## Executar Testes Unitários
- Na raiz do projeto, navegue para o projeto de testes ` cd .\InvestimentoApi\Investimento.UnitTests\`
- Execute `dotnet test --project='.\InvestimentoApi\Investimento.UnitTests\'`
- Navegue para o projeto de testes de frontend `cd .InvestimentoApi\Investimento` e execute `ng test`
