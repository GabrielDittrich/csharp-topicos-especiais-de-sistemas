using Microsoft.EntityFrameworkCore;

public class BancoDeDados : DbContext
{
    // public ExemploContext() : base("ConexaoExemplo"){}
    public DbSet<Pessoa> Pessoas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password=\"admin\"");
    }
}