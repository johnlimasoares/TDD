namespace TestDrivenDevelopment.Leilao
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario(string nome) { this.Nome = nome; }

        public override bool Equals(object obj)
        {

            if (obj == null || obj.GetType() != obj.GetType()) {
                return false;
            }

            Usuario outro = (Usuario)obj;

            return outro.Id == this.Id && outro.Nome == this.Nome;
        }
    }
}