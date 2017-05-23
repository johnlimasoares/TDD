using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDevelopment.Leilao;
/// <summary>
/// Em primeiro lugar, escrevemos um teste; o rodamos e o vimos falhar; em seguida, escrevemos o código mais simples para passar o teste; 
/// rodamos-o novamente, e dessa vez ele passou; por fim, refatoramos nosso código para que ele fique melhor e mais claro.
/// </summary>

namespace TestDrivenDevelopmentTest
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            var leilao = new Leilao("Mac book Pro");
            Assert.AreEqual(0, leilao.Lances.Count);

            var usuario = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(usuario, 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            var leilao = new Leilao("Mac book Pro");

            var steve = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(steve, 2000));

            var bonamassa = new Usuario("Bonamassa");
            leilao.Propoe(new Lance(bonamassa, 5000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
            Assert.AreEqual(5000, leilao.Lances[1].Valor);
        }

        [Test]
        public void NaoPodeHaverDoisLancesSeguidosMesmoUsuario()
        {
            var leilao = new Leilao("Mac book Pro");

            var steve = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(steve, 2000));
            leilao.Propoe(new Lance(steve, 2500));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
        }

        [Test]
        public void NaoPodeHaverMaisQueCincoLancesDoMesmoUsuario()
        {
            var leilao = new Leilao("Mac book Pro");

            var steve = new Usuario("Steve Jobs");
            var uncleBob = new Usuario("Uncle Bob");

            leilao.Propoe(new Lance(steve, 2000));
            leilao.Propoe(new Lance(uncleBob, 2500));
            leilao.Propoe(new Lance(steve, 3500));
            leilao.Propoe(new Lance(uncleBob, 4500));
            leilao.Propoe(new Lance(steve, 5500));
            leilao.Propoe(new Lance(uncleBob, 6500));
            leilao.Propoe(new Lance(steve, 7500));
            leilao.Propoe(new Lance(uncleBob, 8500));
            leilao.Propoe(new Lance(steve, 9500));
            leilao.Propoe(new Lance(uncleBob, 10500));
            leilao.Propoe(new Lance(steve, 11500));//deve ser desconsiderado

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimoLance = leilao.Lances.Count - 1;
            Assert.AreEqual(10500, leilao.Lances[ultimoLance].Valor);

        }
    }
}
