using NUnit.Framework;
using TestDrivenDevelopment.Leiloes;

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
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;
        private Usuario pedro;
        private Usuario ana;

        [SetUp]
        public void CriaObjetos()
        {
            leiloeiro = new Avaliador();
            joao = new Usuario("joao");
            jose = new Usuario("Jose");
            maria = new Usuario("Maria");
            pedro = new Usuario("pedro");
            ana = new Usuario("Ana");
        }

        [Test]
        public void LancesEmOrdemCrescentes()
        {
            var leilao = new CriadorDeLeilao().Para("Casa 500m")
            .Lance(jose, 1000)
            .Lance(joao, 1300)
            .Lance(maria, 6600)
            .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(6600, leiloeiro.GetMaiorLance());
            Assert.AreEqual(1000, leiloeiro.GetMenorLance());
            Assert.AreEqual(2966.66, leiloeiro.GetValorMedioLances(), 0.01);
        }

        [Test]
        public void LancesEmOrdemDecrescentes()
        {
            var leilao = new CriadorDeLeilao().Para("Mustang")
            .Lance(maria, 6600)
            .Lance(joao, 1300)
            .Lance(jose, 1000)
            .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(6600, leiloeiro.GetMaiorLance());
            Assert.AreEqual(1000, leiloeiro.GetMenorLance());
            Assert.AreEqual(2966.66, leiloeiro.GetValorMedioLances(), 0.01);
        }

        [Test]
        public void LeilaoComUmLance()
        {
            var leilao = new CriadorDeLeilao().Para("Fazenda")
            .Lance(joao, 1300)
            .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1300, leiloeiro.GetMaiorLance());
            Assert.AreEqual(1300, leiloeiro.GetMenorLance());
            Assert.AreEqual(1300, leiloeiro.GetValorMedioLances(), 0.01);
        }

        [Test]
        public void TestarTresMaioresLances()
        {
            var leilao = new CriadorDeLeilao().Para("Terreno")
            .Lance(maria, 1300.50)
            .Lance(joao, 1100.00)
            .Lance(ana, 800.00)
            .Lance(pedro, 1300.00)
            .Constroi();

            leiloeiro.Avalia(leilao);

            var maioresLances = leiloeiro.GetTresMaioresLances();
            Assert.AreEqual(3, maioresLances.Count);
            Assert.AreEqual(1300.50, maioresLances[0].Valor);
            Assert.AreEqual(1300.00, maioresLances[1].Valor);
            Assert.AreEqual(1100.00, maioresLances[2].Valor);
        }
    }
}
