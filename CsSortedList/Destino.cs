using System;

namespace MaqTubosCs
{
    /// <summary>Classe interna utilizada para apontar as ligações.</summary>
    public class Destino
    {
        /// <summary>Altura no tubo destino</summary>
        public Int64 altura;

        /// <summary>Numero do tubo destino. </summary>
        public Int64 tuboDestino;

        /// <summary>Classe auxiliar usada para representar o alvo de uma ligação com o tubo atual.</summary>
        /// <param name="altura">altura para onde a ligação aponta.</param>
        /// <param name="tuboDestino">tubo que recebe a ligação.</param>
        public Destino(Int64 altura, Int64 tuboDestino)
        {
            this.altura = altura;
            this.tuboDestino = tuboDestino;
        }

        public Validacao Valida()
        {
            if (altura == -1 && tuboDestino == -1)
            {
                return Validacao.Erro;
            }

            if (tuboDestino == -1)
            {
                return Validacao.Fim;
            }

            return Validacao.Desvio;
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