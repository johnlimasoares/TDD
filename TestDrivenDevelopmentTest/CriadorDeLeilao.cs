using System;
using TestDrivenDevelopment.Leiloes;

namespace TestDrivenDevelopment
{
    public class CriadorDeLeilao
    {
        private Leilao leilao;

        public CriadorDeLeilao Para(string bens)
        {
            leilao = new Leilao(bens);
            return this;
        }

        public CriadorDeLeilao Lance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}