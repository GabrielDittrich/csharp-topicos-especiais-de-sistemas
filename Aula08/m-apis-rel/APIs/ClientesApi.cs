using Microsoft.EntityFrameworkCore;

public static class ClientesApi
{
  public static void MapClientesApi(this WebApplication app)
  {
    var group = app.MapGroup("/clientes");

    group.MapGet("/", async (BancoDeDados db) =>
      {
        //select * from clientes
        return await db.Clientes.Include(c => c.Endereco).ToListAsync();
      }
    );

    /**
      Exemplo de POST
      // Pode ser cadastrado cliente com 
      // endereços novos (sem Ids) ou 
      // endereços existentes (com Ids).
        
      {
        "nome": "João",
        "cpf": "22222",
        "telefone": "2222",
        "email": "e@e.com",
        "enderecos": [
          {
            "rua": "Rua a",
            "numero": "1",
            "bairro": "C",
            "cidade": "Curitiba",
            "cep": "44444"
          },
          {
            "id": 6
          }
        ]
      }

    */
    group.MapPost("/", async (Cliente cliente, BancoDeDados db) =>
      {
        Console.WriteLine($"Cliente: {cliente}");

        // Tratamento para salvar endereço com e sem Ids.
        cliente.Endereco = await SalvarEndereco(cliente, db);
        
        db.Clientes.Add(cliente);
        //insert into...
        await db.SaveChangesAsync();

        return Results.Created($"/clientes/{cliente.Id}", cliente);
      }
    );

    async Task<Endereco?> SalvarEndereco(Cliente cliente, BancoDeDados db)
    {
      Endereco? enderecoRetorno = cliente.Endereco;
      if (enderecoRetorno is not null){
        Console.WriteLine($"Endereço: {enderecoRetorno}");
        if (enderecoRetorno.Id > 0)
        {
          var eExistente = await db.Enderecos.FindAsync(enderecoRetorno.Id);
          if (eExistente is not null)
          {
            enderecoRetorno = eExistente;
          }
        }
      }
      return enderecoRetorno;
    }

    group.MapPut("/{id}", async (int id, Cliente clienteAlterado, BancoDeDados db) =>
      {
        //select * from clientes where id = ?
        var cliente = await db.Clientes.FindAsync(id);
        if (cliente is null)
        {
            return Results.NotFound();
        }
        cliente.Nome = clienteAlterado.Nome;
        cliente.Telefone = clienteAlterado.Telefone;
        cliente.Email = clienteAlterado.Email;
        cliente.CPF = clienteAlterado.CPF;

        // Tratamento para salvar endereço com e sem Ids.
        cliente.Endereco = await SalvarEndereco(cliente, db);

        //update....
        await db.SaveChangesAsync();

        return Results.NoContent();
      }
    );

    group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
      {
        if (await db.Clientes.FindAsync(id) is Cliente cliente)
        {
          //Operações de exclusão
          db.Clientes.Remove(cliente);
          //delete from...
          await db.SaveChangesAsync();
          return Results.NoContent();
        }
        return Results.NotFound();
      }
    );
  }
}