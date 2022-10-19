namespace WebApiZap.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Precio { get; set; }
        public string Marca { get; set; }

        //conectando entidades
        public int ZapatoId { get; set; }
        public Zapato Zapato { get; set; }
    }
}
