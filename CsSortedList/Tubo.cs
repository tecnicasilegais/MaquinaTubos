using System;
using System.Collections.Generic;

namespace MaqTubosCs
{
    /// <summary>Classe contendo uma definição de Tubo para resolução do problema.</summary>
    public class Tubo
    {
        #region Construtor

        /// <summary>Cria uma Instancia de tubo começando com 0 bolas e com uma lista vazia de ligações.</summary>
        public Tubo(Int64 alturaMaquina)
        {
            _alturaMaquina = alturaMaquina;
            _qtdBolas = 0;
            _ligacoes = new SortedList<Int64, Destino>();
        }

        #endregion

        #region Atributos

        private readonly Int64 _alturaMaquina;
        public Int64 _qtdBolas;
        private readonly SortedList<Int64, Destino> _ligacoes;

        #endregion

        #region Metodos

        /// <summary>Adiciona uma ligação ao tubo atual usando os dados recebidos.</summary>
        /// <param name="altura">altura do tubo atual</param>
        /// <param name="tuboDestino">tubo para onde a ligação aponta</param>
        /// <param name="alturaDestino">altura do tubo para onde a ligação aponta</param>
        /// <returns></returns>
        public Boolean AdicionarLigacao(Int64 altura, Int64 tuboDestino, Int64 alturaDestino)
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

        /// <summary>Procura uma conexão saindo do tubo atual a partir da altura recebida</summary>
        /// <param name="alturaAtual">altura de onde parte a pesquisa.</param>
        /// <returns></returns>
        public Destino ProcuraConexao(Int64 alturaAtual)
        {
            try
            {
                //percorre a Lista a partir da posição da altura que foi recebida e procura conexões com outra bolinha
                for (Int64 i = alturaAtual; i < _alturaMaquina; i++)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Destino(-1, -1);
            }
        }

        #endregion
    }
}