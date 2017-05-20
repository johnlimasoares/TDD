namespace TestDrivenDevelopment.Leilao
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario(string nome) { this.Nome = nome; }
    }
}