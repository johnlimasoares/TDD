using NUnit.Framework;
using System;
using TestDrivenDevelopment.Leilao;

namespace TestDrivenDevelopment
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Main()
        {
            var joao = new Usuario("joao");
            var jose = new Usuario("Jose");
            var maria = new Usuario("Maria");

            var leilao = new Leilao.Leilao("Casa");
            leilao.Propoe(new Lance(jose, 1000));
            leilao.Propoe(new Lance(joao, 1300));
            leilao.Propoe(new Lance(maria, 66000));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);


            Assert.AreEqual(66000, avaliador.GetMaiorLance());
            Assert.AreEqual(1000, avaliador.GetMenorLance());
        }
    }
}
