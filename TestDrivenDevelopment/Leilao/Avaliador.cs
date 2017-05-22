using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopment.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double valorMedioLances;
        private List<Lance> listaMaioresLances;

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {

                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }

                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
                                
            }

            CalculaValorMedio(leilao);
            ObterMaioresLances(leilao);

        }

        private void CalculaValorMedio(Leilao leilao)
        {
            valorMedioLances = (leilao.Lances.Sum(x => x.Valor) / leilao.Lances.Count);
        }

        private void ObterMaioresLances(Leilao leilao)
        {
            listaMaioresLances = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor)).GetRange(0, leilao.Lances.Count >= 3 ? 3 : leilao.Lances.Count);
        }

        public double GetMaiorLance() { return maiorDeTodos; }
        public double GetMenorLance() { return menorDeTodos; }
        public double GetValorMedioLances() { return valorMedioLances; }
        public List<Lance> GetTresMaioresLances() { return listaMaioresLances; }
    }
}
