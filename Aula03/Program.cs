var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "app.MapGet");

app.Run();
