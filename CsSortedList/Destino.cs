using System;
using System.Collections.Generic;
using System.Text;

namespace MaqTubosCs
{
    /// <summary>Classe interna utilizada para apontar as ligações.</summary>
    public class Destino
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

        public Validacao Valida()
        {
            if (this.altura == -1 && this.tuboDestino == -1)
            {
                return Validacao.Erro;
            }
            else if (this.tuboDestino == -1)
            {
                return Validacao.Fim;
            }
            else return Validacao.Desvio;
        }
    }
    /// <summary>Valida uma instancia da classe Destino</summary>
    public enum Validacao
    {
        Fim = 'F',
        Erro = 'E',
        Desvio = 'D'
    }
}
