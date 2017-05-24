using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDevelopment;
using TestDrivenDevelopment.Leiloes;
/// <summary>
/// Em primeiro lugar, escrevemos um teste; o rodamos e o vimos falhar; em seguida, escrevemos o código mais simples para passar o teste; 
/// rodamos-o novamente, e dessa vez ele passou; por fim, refatoramos nosso código para que ele fique melhor e mais claro.
/// </summary>

namespace TestDrivenDevelopmentTest
{
    [TestFixture]
    public class LeilaoTest
    {
        private Avaliador leiloeiro;
        private Usuario steve;
        private Usuario bonamassa;
        private Usuario uncleBob;

        [SetUp]
        public void CriaObjetos()
        {
            leiloeiro = new Avaliador();
            steve = new Usuario("Steve Jobs");
            bonamassa = new Usuario("Joe Bonamassa");
            uncleBob = new Usuario("Uncle Bob");
        }

        [Test]
        public void DeveReceberUmLance()
        {
            var leilao = new CriadorDeLeilao().Para("Mac Book")
            .Constroi();
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao = new CriadorDeLeilao().Para("Mac Book")
            .Lance(steve, 2000).Constroi();

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            var leilao = new CriadorDeLeilao().Para("tablet")
            .Lance(steve, 2000)
            .Lance(bonamassa, 5000)
            .Constroi();

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
            Assert.AreEqual(5000, leilao.Lances[1].Valor);
        }

        [Test]
        public void NaoPodeHaverDoisLancesSeguidosMesmoUsuario()
        {
            var leilao = new CriadorDeLeilao().Para("Smartphone")
            .Lance(steve, 2000)
            .Lance(steve, 2500)
            .Constroi();

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
        }

        [Test]
        public void NaoPodeHaverMaisQueCincoLancesDoMesmoUsuario()
        {
            var leilao = new CriadorDeLeilao().Para("Mochila")
            .Lance(steve, 2000)
            .Lance(uncleBob, 2500)
            .Lance(steve, 3500)
            .Lance(uncleBob, 4500)
            .Lance(steve, 5500)
            .Lance(uncleBob, 6500)
            .Lance(steve, 7500)
            .Lance(uncleBob, 8500)
            .Lance(steve, 9500)
            .Lance(uncleBob, 10500)
            .Lance(steve, 11500)//deve ser desconsiderado
            .Constroi();

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimoLance = leilao.Lances.Count - 1;
            Assert.AreEqual(10500, leilao.Lances[ultimoLance].Valor);

        }
    }
}
