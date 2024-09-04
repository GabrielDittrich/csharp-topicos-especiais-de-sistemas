using Microsoft.EntityFrameworkCore;

public static class ProdutosApi
{
  public static void MapProdutosApi(this WebApplication app)
  {
    var group = app.MapGroup("/produtos");

    group.MapGet("/", async (BancoDeDados db) =>
      //select * from produtos
      await db.Produtos.ToListAsync()
    );

    group.MapPost("/", async (Produto produto, BancoDeDados db) =>
      {
        db.Produtos.Add(produto);
        //insert into...
        await db.SaveChangesAsync();

        return Results.Created($"/produtos/{produto.Id}", produto);
      }
    );

    group.MapPut("/{id}", async (int id, Produto produtoAlterado, BancoDeDados db) =>
      {
        //select * from produtos where id = ?
        var produto = await db.Produtos.FindAsync(id);
        if (produto is null)
        {
            return Results.NotFound();
        }
        produto.Nome = produtoAlterado.Nome;
        produto.Valor = produtoAlterado.Valor;

        //update....
        await db.SaveChangesAsync();

        return Results.NoContent();
      }
    );

    group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
      {
        if (await db.Produtos.FindAsync(id) is Produto produto)
        {
          //Operações de exclusão
          db.Produtos.Remove(produto);
          //delete from...
          await db.SaveChangesAsync();
          return Results.NoContent();
        }
        return Results.NotFound();
      }
    );
  }
}