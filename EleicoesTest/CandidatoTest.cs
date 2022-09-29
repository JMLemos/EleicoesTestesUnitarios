using Eleicoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicoesTest
{
    public class CandidatoTest
    {

        [Fact]
        public void ValidarNomeCandidato()
        {

            //Arrange

            string nome = "João";
            var candidato = new Candidato(nome);

            //Act
            var retorno = candidato.Nome;
            
            //Assert
            Assert.Equal(nome, retorno);

        }

        [Fact]
        public void ValidarVotosCandidato()
        {
            //Arrange
            var candidato = new Candidato("João")
            {
               Votos = 10
            };

            //Act 
            candidato.AdicionarVoto();
            var retorno = candidato.RetornarVotos();

            //Assert
            Assert.Equal(candidato.Votos ,retorno);


        }
    }
}
