using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração de banco de dados
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("tarefas")
);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

app.MapGet("/", () => "API de Tarefas");

app.MapGet("/tarefas", async (AppDbContext db) =>
{

    //  select * from tarefas
    return await db.Tarefas.ToListAsync();

    /*  List<Tarefa> lista = new();

      Tarefa tarefas1 = new Tarefa();
      tarefas1.Id = 1;
      tarefas1.Nome = "Comprar verduras";
      tarefas1.Concluida = false;


      lista.Add(tarefas1);

      Tarefa tarefa2 = new Tarefa();
      tarefa2.Id = 2;
      tarefa2.Nome = " Chora ";
      tarefa2.Concluida = true;
      lista.Add(tarefa2); 
    return lista;
  */

});

app.MapGet("/tarefas/concluidas", async (AppDbContext db) =>
{

    //  select * from tarefas t where t.Concluida = true
    return await db.Tarefas.Where(t => t.Concluida).ToListAsync();

});

app.MapGet("/tarefas/{id}", async (int id, AppDbContext db) =>
{
    // select*from tarefas t where t.Id = ?
    return await db.Tarefas.FindAsync(id) is Tarefa tarefa ? Results.Ok
    (tarefa) : Results.NotFound();
});


app.MapPost("/tarefas", async (Tarefa tarefa, AppDbContext db) =>
{
    db.Tarefas.Add(tarefa);
    await db.SaveChangesAsync();

    return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
});


app.MapPut("/tarefas/{id}", async (int Id, Tarefa tarefaAlterada, AppDbContext db) =>
{
    // select * from where id = ?
    var tarefa = await db.Tarefas.FindAsync(Id);
    if (tarefa == null) return Results.NotFound();

    tarefa.Nome = tarefaAlterada.Nome;
    tarefa.Concluida = tarefaAlterada.Concluida;

    // update from...    / commit 
    await db.SaveChangesAsync();
    return Results.NoContent();
});


app.MapDelete("/tarefas/{id}", async (int Id, AppDbContext db) =>
{
    if (await db.Tarefas.FindAsync(Id) is Tarefa tarefa)
    {
        db.Tarefas.Remove(tarefa);

        // delete from... / where id ?
        await db.SaveChangesAsync();
        return Results.NoContent();

    }
    return Results.NotFound();
});


app.Run();

