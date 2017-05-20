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

        public void Avalia(Leilao leilao) {
            foreach (var lance in leilao.Lances) {

                if (lance.Valor > maiorDeTodos) {
                    maiorDeTodos = lance.Valor;
                }

                if (lance.Valor < menorDeTodos) {
                    menorDeTodos = lance.Valor;
                }
            }

        }

        public double GetMaiorLance() { return maiorDeTodos; }
        public double GetMenorLance() { return menorDeTodos; }
    }
}
