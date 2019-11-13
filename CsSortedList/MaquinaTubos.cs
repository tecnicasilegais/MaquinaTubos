using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MaqTubosCs
{
    ///<summary> Classe contendo engine da maquina de tubos</summary>
    public class MaquinaTubos
    {
        #region Atributos
        private long _nroTubos;
        private long _altura;
        private Tubo[] _tubos;

        #endregion

        #region Propriedades
        #endregion

        #region Construtor
        
        /// <summary>Metodo construtor que cria uma nova instância da Maquina de Tubos</summary>
        /// <param name="nroTubos">Quantidade de tubos que a maquina terá.</param>
        /// <param name="altura">Numero de altura da maquina.</param>
        public MaquinaTubos(long nroTubos, long altura)
        {
            this._nroTubos = nroTubos;
            this._altura = altura; 

            ///<summary>Inicializa um vetor de Tubos com o tamanho sendo a quantidade de tubos definida pelo usuário.</summary>
            ///<see cref="Tubo"/>
            _tubos = new Tubo[nroTubos];

            ///<summary>Cria uma instância de Tubo para cada posição no vetor</summary>
            for (long i=0; i<nroTubos; i++)
            {
                _tubos[i] = new Tubo();
            }


        }
        #endregion

        #region Metodos
        /// <summary>
        /// Recebe uma linha de conexao numérica no padrao "a b c d"
        /// a -> tubo de partida
        /// b -> altura do tubo na conexao
        /// c -> tubo destino
        /// d -> altura do tubo destino na conexao
        /// executa a inserção dessa conexao na lógica da maquina.</summary>
        /// <param name="tuboPartida">Tubo de onde a conexão parte</param>
        /// <param name="altura">altura de onde a conexão parte</param>
        /// <param name="tuboDestino">tubo para onde a conexao vai</param>
        /// <param name="alturaDestino">altura do tubo para onde a conexão vai</param>
        /// <returns></returns>
        public Boolean InsereConexao(long tuboPartida, long altura, long tuboDestino, long alturaDestino)
        {
            try
            {
                _tubos[tuboPartida].AdicionarLigacao(altura, tuboDestino, alturaDestino);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
