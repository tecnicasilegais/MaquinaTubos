using System;
using System.Collections.Generic;
using System.Text;

namespace MaqTubosCs
{
    /// <summary>Classe contendo uma definição de Tubo para resolução do problema.</summary>
    public class Tubo
    {
        #region Atributos
        public long _qtdBolas;
        private SortedList<Int64, Destino> _ligacoes;
        /// <summary>Classe interna utilizada para apontar as ligações.</summary>
        internal class Destino
        {
            /// <summary>Altura no tubo destino</summary>
            public long altura;
            /// <summary>Numero do tubo destino. </summary>
            public long tuboDestino;

            /// <summary>Classe auxiliar usada para representar o alvo de uma ligação com o tubo atual.</summary>
            /// <param name="altura">altura para onde a ligação aponta.</param>
            /// <param name="tuboDestino">tubo que recebe a ligação.</param>
            public Destino(long altura, long tuboDestino)
            {
                this.altura = altura;
                this.tuboDestino = tuboDestino;
            }
        }

        #endregion

        #region Construtor
        /// <summary>Cria uma Instancia de tubo começando com 0 bolas e com uma lista vazia de ligações.</summary>
        public Tubo()
        {
            this._qtdBolas = 0;
            this._ligacoes = new SortedList<long, Destino>();
        }
        #endregion

        #region Metodos
        /// <summary>Adiciona uma ligação ao tubo atual usando os dados recebidos.</summary>
        /// <param name="altura">altura do tubo atual</param>
        /// <param name="tuboDestino">tubo para onde a ligação aponta</param>
        /// <param name="alturaDestino">altura do tubo para onde a ligação aponta</param>
        /// <returns></returns>
        public Boolean AdicionarLigacao(long altura, long tuboDestino, long alturaDestino)
        {
            try
            {
                _ligacoes.Add(altura, new Destino(alturaDestino, tuboDestino));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }

}
