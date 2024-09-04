

public class Pedido
{
    public int Id { get; set; }
    public DateTime? Data { get; set; }
    public double? Total { get; set; }

    // Relacionamento muitos para 1
    public Cliente? Cliente { get; set; }

    // Relacionamento 1 para muitos
    public List<ItemPedido>? Itens { get; set; }

}