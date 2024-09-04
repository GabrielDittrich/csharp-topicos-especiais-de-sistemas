using Microsoft.EntityFrameworkCore;

public static class PedidosApi
{
  public static void MapPedidosApi(this WebApplication app)
  {
    var group = app.MapGroup("/pedidos");

    group.MapGet("/", async (BancoDeDados db) =>
      {
        //select * from pedidos
        return await db.Pedidos.Include(p => p.Cliente).Include(p => p.Itens).ToListAsync();
      }
    );

    group.MapPost("/", async (Pedido pedido, BancoDeDados db) =>
      {
        Console.WriteLine($"Pedido: {pedido}");

        // Tratamento para salvar itens com e sem Ids.
        pedido.Itens = await SalvarItens(pedido, db);
        
        db.Pedidos.Add(pedido);
        //insert into...
        await db.SaveChangesAsync();

        return Results.Created($"/pedidos/{pedido.Id}", pedido);
      }
    );

    async Task<List<ItemPedido>> SalvarItens(Pedido pedido, BancoDeDados db)
    {
      List<ItemPedido> itens = new();
      if (pedido is not null && pedido.Itens is not null 
          && pedido.Itens.Count > 0){

        foreach (var item in pedido.Itens)
        {
          Console.WriteLine($"Item: {item}");
          if (item.Id > 0)
          {
            var iExistente = await db.ItensPedido.FindAsync(item.Id);
            if (iExistente is not null)
            {
              itens.Add(iExistente);
            }
          }
          else
          {
            itens.Add(item);
          }
        }
      }
      return itens;
    }

    group.MapPut("/{id}", async (int id, Pedido pedidoAlterado, BancoDeDados db) =>
      {
        //select * from pedidos where id = ?
        var pedido = await db.Pedidos.FindAsync(id);
        if (pedido is null)
        {
            return Results.NotFound();
        }

        pedido.Data = pedidoAlterado.Data;
        pedido.Total = pedidoAlterado.Total;
        pedido.Cliente = pedidoAlterado.Cliente;

        // Tratamento para salvar itens com e sem Ids.
        pedido.Itens = await SalvarItens(pedidoAlterado, db);

        //update....
        await db.SaveChangesAsync();

        return Results.NoContent();
      }
    );

    group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
      {
        if (await db.Pedidos.FindAsync(id) is Pedido pedido)
        {
          //Operações de exclusão
          db.Pedidos.Remove(pedido);
          //delete from...
          await db.SaveChangesAsync();
          return Results.NoContent();
        }
        return Results.NotFound();
      }
    );
  }
}