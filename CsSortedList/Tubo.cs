using System;
using System.Collections.Generic;
using System.Text;

namespace MaqTubosCs
{
    public class Tubo
    {
        #region Atributos
        public long _qtdBolas;
        private SortedList<Int64, Destino> _ligacoes;
        internal class Destino
        {
            private long altura;
            private long tuboDestino;
        }

        #endregion

        #region Construtor
        public Tubo()
        {
            this._qtdBolas = 0;
            this._ligacoes = new SortedList<long, Destino>();
        }
        #endregion

    }

}
