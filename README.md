# Plataforma Investimento
Desafio de Programação
## Pré-requisitos
- .Net Core 3.0: https://dotnet.microsoft.com/download/dotnet-core/3.0
- Docker Toolbox: https://github.com/docker/toolbox/releases
- Node v10.16.3 (inclui npm): https://nodejs.org/en/download/
- Angular Cli 8.3.+ : execute 'npm install -g @angular/cli' no terminal
## Instalação
Depois de atender os Pré-requisitos:
- Clone o repositório: git clone https://github.com/raviassis/plataforma_investimento.git
- execute no terminal do docker o comando `docker run -p 8080:8080 toroinvestimentos/quotesmock`
- Execute a api: dotnet run --project='.\InvestimentoApi\InvestimentoApi\'
- Acesse o caminho plataforma_investimento/InvestimentoClient: cd plataforma_investimento/InvestimentoClient
- Instale as dependências: npm install
- Execute o projeto do front: ng serve -o
