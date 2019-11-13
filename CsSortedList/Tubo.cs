using System;
using System.Collections.Generic;
using System.Text;

namespace MaqTubosCs
{
    /// <summary>Classe contendo uma definição de Tubo para resolução do problema.</summary>
    public class Tubo
    {
        #region Atributos
        private long _alturaMaquina;
        public long _qtdBolas;
        private SortedList<Int64, Destino> _ligacoes;
 

        #endregion

        #region Construtor
        /// <summary>Cria uma Instancia de tubo começando com 0 bolas e com uma lista vazia de ligações.</summary>
        public Tubo(long alturaMaquina)
        {
            this._alturaMaquina = alturaMaquina;
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

        public Destino ProcuraConexao(long alturaAtual)
        {
            try
            {
                //percorre a Lista a partir da posição da altura que foi recebida e procura conexões com outra bolinha
                for (long i = alturaAtual; i < _alturaMaquina; i++)
                {
                    //Se encontar uma chave com o valor de altura, significa q ele sai do tubo neste ponto
                    if (_ligacoes.ContainsKey(i))
                    {
                        return _ligacoes[i];
                    }
                }
                //se não encontrar uma chave, significa q ele fica no tubo até o fim.
                return new Destino(_alturaMaquina, -1);
            }
            catch (Exception)
            {
                return new Destino(-1, -1);
            }
        }
        #endregion
    }

}
