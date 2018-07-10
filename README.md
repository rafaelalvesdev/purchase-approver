
## Gestor de Aprovação de Compras

#### Dependências
Para executar o projeto em DEBUG será necessário instalar os componentes abaixo:
* Visual Studio 15.7 ou superior
* Node v8.11 ou superior
* .NET Core 2.1 SDK (v2.1.302) ou superior
* .NET Core 2.1 Runtime (v2.1.2) ou superior
* Angular 6

#### Implantação
1. Baixar repositório https://github.com/rafaelalvesdev/purchase-approver
```git clone https://github.com/rafaelalvesdev/purchase-approver```
2. Abrir solution no Visual Studio
3. Configurar Connection String `ConnectionStrings / DefaultConnection` para conexão com o banco no arquivo `code/SafeWeb.PurchaseApprover.Web/appsettings.json`
4. Executar projeto SafeWeb.PurchaseApprover.Web em modo DEBUG.


#### Padrões e componentes utilizados
O sistema foi construído utilizando o padrão SOA (_Service oriented architecture_) utilizando pequenos serviços para manipulação de dados.
Para persistência de entidades foi utilizado o Entity Framwork Core, através do padrão Code First, ao executar o projeto o framework criará a database, entidades necessárias e executará o seed para funcionamento inicial.

A API backend está desenvolvida em Web API com ASP.NET Core e o frontend é apresentado através de Angular em uma aplicação SPA integrada ao .Net.

É possível acessar e executar métodos da API através do Swagger instalado em `/swagger/`.
