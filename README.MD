
# TestAPICSharp

Uma API criada usando C# e alguns Frameworks .NET.




## Documentação da API

#### Retorna todos os Clientes

```http
  GET /api/Clientes
```

#### Retorna um Cliente

```http
  GET /api/Clientes/${id}
```

#### Adiciona um Cliente

```http
  POST /api/Clientes/${id}
```

#### Edita um Cliente

```http
  PUT /api/Clientes/${id}
``` 

#### Deleta um Cliente

```http
  DELETE /api/Clientes/${id}
```


## Referência

 - [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
 - [Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
 - [Migrations](https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
 - [Controller ](https://learn.microsoft.com/pt-br/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs?source=recommendations)


## Step by step

Criar um novo projeto API Web do ASP.NET Core (C#), Framework .NET 6.0

Criar uma classe com algumas propriedades, por ex.: `Id, Nome, Email` etc.

Usar uma anotation no `Id [StringLength(20)]`

Instalar pacotes nuget: 

    AspNet.WebApi.Cors 

    EntityFrameworkCore, Core.Design, Core.SqlServer, Core.Tools

    VisualStudio.Web.CodeGeneration.Design

Criar o ponto de acesso com o db.  Nova pasta `Data`, nova class `DataContext`

DataContext recebendo nosso DbContext

`public DataContext(DbContextOptions<DataContext> options): base(options) {}`

Setar para o db. No caso temos apenas o Cliente para setar.

`public DbSet<Cliente>? Clientes { get; set; }`. Usando um ? como nullable

Pro programa entender que ele vai usar isso, precisamos setar la no program.cs o seguinte:

`builder.Services.AddDbContext<DataContext>()`

agora precisamos passar a instrucao/setar pra dentro dele

`builder.Services.AddDbContext<DataContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);`

ja setamos que ele vai usar `SqlServer` e passamos como sera a conexao.

Agora temos que ir em `appsettings.json` e adicionar o `ConnectionStrings` pra ele entender onde estar o servidor.

`"ConnectionStrings": {
"DefaultConnection":`

Pra achar o endereco que vai dentro, vamos em SQL server object > propriedades e copiamos o endereco. Podemos mudar o catalog para o nome que quisermos que seja nosso db.

Agora vamos usar o Cors que instalamos com o Nuget. Ele servira para “abrir” nossas conexoes. 

Mais sobre CORS nesses links:

[Cross-Origin Resource Sharing (CORS) - HTTP | MDN](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/CORS#:~:text=CORS%20-%20Cross-Origin%20Resource%20Sharing,um%20servidor%20em%20uma%20origem)

[Habilitar solicitações entre origens (CORS) no ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-7.0)

A documentacao acima diz para criarmos uma variavel do seguinte modo:

`var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";`

usaremos ela no nosso Program.cs

Depois precisamos buildar nosso serviço. Vamos substituir o "http://example.com" por "http://localhost:4200"

Abaixo inserimos o codigo que esta abaixo para usarmos essa estrutura do cors:
`app.UseCors(MyAllowSpecificOrigins);`

Agora vamos para o processo das migrations. Vamos usar o Console para executar alguns comandos.

Segundo a documentacao citada na sessao migrations, temos que usar os seguintes comandos:

`dotnet ef migrations add InitialCreate` 

`InitialCreate` é o nome do exemplo da documentacao, mas poderia ser outro.

Agora usamos `dotnet ef database update` para criar nosso db e nosso schema.

Agora por ultimo, precisamos criar nossas controllers.

Controllers > adicionar > controlador > API > Controlador API com ações, usando EF.

Com isso, ele cria nossa controller, com nossas rotas.

Agora podemos fazer os testes da nossa API com o swagger ou o postman.
