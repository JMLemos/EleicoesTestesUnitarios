using Eleicoes;
using FluentAssertions;

namespace EleicoesTest
{
    public class UrnaTest
    {

        [Fact]
        public void TestarConstrutor()
        {
            //Arrange
            var urna = new Urna();

            //Act
            var comparar = new Urna
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false
            };

            //Assert
            comparar.Should().BeEquivalentTo(urna);
        }

        [Fact]
        public void TestarInicioEncerramentoDaEleicao()
        {
            //Arrange
            var urna = new Urna();

            //Act
            var result = urna.EleicaoAtiva;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestarCadastroCandidato()
        {
            //Arrange
            var urna = new Urna();
            urna.CadastrarCandidato("João");

            //Act
            var resultadoInserido = urna.Candidatos.Where(x => x.Nome == "João").FirstOrDefault();

            var resultadoLista = urna.Candidatos.Last();

            //Assert
            resultadoLista.Should().BeEquivalentTo(resultadoInserido);
        }

        [Fact]
        public void ValidarVotacao_CandidatoNaoCadastrado()
        {
            //Arrange
            var urna = new Urna();
            var candidatoNaoExiste = "Pedrinho";

            //Act
            var resultado = urna.Candidatos.Where(x => x.Nome == candidatoNaoExiste).FirstOrDefault();

            //Assert
            resultado.Should().NotBeEquivalentTo(candidatoNaoExiste);
            Assert.False(urna.Votar(candidatoNaoExiste));
        }

        [Fact]
        public void ValidarVotacao_CandidatoCadastrado()
        {
            //Arrange
            var urna = new Urna();
            urna.CadastrarCandidato("João");
            var candidatoExiste = "João";

            //Act
            var resultado = urna.Candidatos.Where(x => x.Nome == candidatoExiste).FirstOrDefault();

            //Assert
            resultado.Equals(candidatoExiste);
            Assert.True(urna.Votar(candidatoExiste));

        }

        [Fact]
        public void ValidandoResultadoEleicoes()
        {
            //Arrange
            var urna = new Urna();

            //Act 
            urna.CadastrarCandidato("João");
            urna.CadastrarCandidato("Ana");
            urna.CadastrarCandidato("Lucas");

            
            urna.Votar("João");
            urna.Votar("Ana");
            urna.Votar("Ana");
            urna.Votar("Lucas");

            var esperado = "Nome vencedor: Ana. Votos: 2";

            var resultado = urna.MostrarResultadoEleicao();

            //Assert
            resultado.Equals(esperado);
        }
    }
}
