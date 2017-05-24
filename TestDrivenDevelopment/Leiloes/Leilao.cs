using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopment.Leiloes
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (Lances.Count == 0 || PodeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }

        }

        private bool PodeDarLance(Usuario usuario)
        {
            return !UltimoLanceDado().Usuario.Equals(usuario) && GetTotalLancesUsuario(usuario) < 5;
        }

        private int GetTotalLancesUsuario(Usuario usuario)
        {
            return Lances.Where(x => x.Usuario == usuario).Count();
        }

        private Lance UltimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }
    }
}
