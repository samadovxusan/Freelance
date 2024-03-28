using Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsnyc();

var app = builder.Build();

await app.ConfigureAsnyc();

app.MapGet("/", () => "Hello World!");

app.Run();