using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MaqTubosCs
{
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

        public MaquinaTubos(long nroTubos, long altura)
        {
            this._nroTubos = nroTubos;
            this._altura = altura; 
            _tubos = new Tubo[nroTubos];
            
        }
        #endregion

        #region Metodos

        public void testar(int i)
        {
            Console.WriteLine(
                _tubos[i]._qtdBolas);
        }

        #endregion
    }
}
