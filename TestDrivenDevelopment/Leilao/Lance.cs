using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopment.Leilao
{
    public class Lance
    {
        public Usuario Usuario { get; set; }
        public double Valor { get; set; }

        public Lance(Usuario usuario, double valor) {
            this.Usuario = usuario;
            this.Valor = valor;
        }
    }
}
