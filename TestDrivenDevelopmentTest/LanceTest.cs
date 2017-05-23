using NUnit.Framework;
using TestDrivenDevelopment.Leilao;

/// <summary>
/// O ideal é escrevermos apenas um único teste para cada possível cenário diferente! Por exemplo, um cenário que levantamos é justamente lances em ordem crescente.
/// Já temos um teste para ele: DeveEntenderLancesEmOrdemCrescente(). Não precisamos de outro para o mesmo cenário! Na área de testes de software, chamamos isso de classe de equivalência.
/// Precisamos de um teste por classe de equivalência.
/// </summary>

namespace TestDrivenDevelopment
{
    [TestFixture]
    public class LanceTest
    {
        [Test]
        public void LancesEmOrdemCrescentes()
        {
            var joao = new Usuario("joao");
            var jose = new Usuario("Jose");
            var maria = new Usuario("Maria");

            var leilao = new Leilao.Leilao("Casa");
            leilao.Propoe(new Lance(jose, 1000));
            leilao.Propoe(new Lance(joao, 1300));
            leilao.Propoe(new Lance(maria, 6600));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);


            Assert.AreEqual(6600, avaliador.GetMaiorLance());
            Assert.AreEqual(1000, avaliador.GetMenorLance());
            Assert.AreEqual(2966.66, avaliador.GetValorMedioLances(), 0.01);
        }

        [Test]
        public void LancesEmOrdemDecrescentes()
        {
            var joao = new Usuario("joao");
            var jose = new Usuario("Jose");
            var maria = new Usuario("Maria");

            var leilao = new Leilao.Leilao("Casa");
            leilao.Propoe(new Lance(maria, 6600));
            leilao.Propoe(new Lance(joao, 1300));
            leilao.Propoe(new Lance(jose, 1000));


            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);


            Assert.AreEqual(6600, avaliador.GetMaiorLance());
            Assert.AreEqual(1000, avaliador.GetMenorLance());
            Assert.AreEqual(2966.66, avaliador.GetValorMedioLances(), 0.01);
        }

        [Test]
        public void LeilaoComUmLance()
        {
            var joao = new Usuario("joao");

            var leilao = new Leilao.Leilao("Casa");
            leilao.Propoe(new Lance(joao, 1300));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            Assert.AreEqual(1300, avaliador.GetMaiorLance());
            Assert.AreEqual(1300, avaliador.GetMenorLance());
            Assert.AreEqual(1300, avaliador.GetValorMedioLances(), 0.01);

        }

        [Test]
        public void TestarTresMaioresLances()
        {
            var joao = new Usuario("joao");
            var maria = new Usuario("maria");
            var ana = new Usuario("ana");
            var pedro = new Usuario("pedro");

            var leilao = new Leilao.Leilao("Casa");
            leilao.Propoe(new Lance(maria, 1300.50));
            leilao.Propoe(new Lance(joao, 1100.00));
            leilao.Propoe(new Lance(ana, 800.00));
            leilao.Propoe(new Lance(pedro, 1300.00));


            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            var maioresLances = avaliador.GetTresMaioresLances();
            Assert.AreEqual(3, maioresLances.Count);
            Assert.AreEqual(1300.50, maioresLances[0].Valor);
            Assert.AreEqual(1300.00, maioresLances[1].Valor);
            Assert.AreEqual(1100.00, maioresLances[2].Valor);
        }
    }
}
