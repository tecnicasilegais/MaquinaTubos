using System;
using System.Linq;
using System.Text;

namespace MaqTubosCs
{
    ///<summary> Classe contendo engine da maquina de tubos</summary>
    public class MaquinaTubos
    {
        #region Atributos

        private readonly Int64 _nroTubos;
        private readonly Int64 _altura;
        private readonly Tubo[] _tubos;
        private Boolean _inseriu;

        #endregion

        #region Construtor

        /// <summary>Metodo construtor que cria uma nova instância da Maquina de Tubos</summary>
        /// <param name="nroTubos">Quantidade de tubos que a maquina terá.</param>
        /// <param name="altura">Numero de altura da maquina.</param>
        public MaquinaTubos(Int64 nroTubos, Int64 altura)
        {
            _nroTubos = nroTubos;
            _altura = altura;

            ///<summary>Inicializa um vetor de Tubos com o tamanho sendo a quantidade de tubos definida pelo usuário.</summary>
            ///<see cref="Tubo"/>
            _tubos = new Tubo[nroTubos];

            //na inicialização, ainda não houve inserção de bolinhas no sistema.
            _inseriu = false;

            ///<summary>Cria uma instância de Tubo para cada posição no vetor</summary>
            for (Int64 i = 0; i < nroTubos; i++)
            {
                _tubos[i] = new Tubo(_altura);
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        ///     Recebe uma linha de conexao numérica no padrao "a b c d"
        ///     a -> tubo de partida
        ///     b -> altura do tubo na conexao
        ///     c -> tubo destino
        ///     d -> altura do tubo destino na conexao
        ///     executa a inserção dessa conexao na lógica da maquina.
        /// </summary>
        /// <param name="tuboPartida">Tubo de onde a conexão parte</param>
        /// <param name="altura">altura de onde a conexão parte</param>
        /// <param name="tuboDestino">tubo para onde a conexao vai</param>
        /// <param name="alturaDestino">altura do tubo para onde a conexão vai</param>
        /// <returns></returns>
        public Boolean InsereConexao(Int64 tuboPartida, Int64 altura, Int64 tuboDestino, Int64 alturaDestino)
        {
            try
            {
                //chama o metodo responsavel por adicionar uma ligacao no tubo especifico
                _tubos[tuboPartida].AdicionarLigacao(altura, tuboDestino, alturaDestino);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>Coleta os resultados da inserção na maquina e os imprime em uma String no Console.</summary>
        public void ResultadosConsole()
        {
            StringBuilder sb = new StringBuilder();
            if (_inseriu)
            {
                //inicializando variaveis auxiliares em posição inválida.
                Int64 maxVal = -1;
                Int64 maxIndex = -1;

                //percorre toda lista de tubos fazendo impressão dos dados do resultado.
                //ao mesmo tempo vai verificando o tubo com maior quantidade de saidas.
                for (Int64 i = 0; i < _nroTubos; i++)
                {
                    sb.AppendLine($"Tubo : {i}, bolinhas : {_tubos[i]._qtdBolas}");
                    if (_tubos[i]._qtdBolas > maxVal)
                    {
                        maxVal = _tubos[i]._qtdBolas;
                        maxIndex = i;
                    }
                }

                sb.AppendLine($"Tubo com maior quantidade de bolinhas: {maxIndex}, quantidade: {maxVal}");
                sb.AppendLine($"Quantidade bolinhas: {_nroTubos}, qntd que sairam : {_tubos.Sum(tb => tb._qtdBolas)}");
                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("Você deve executar primeiro a inserção, para depois coletar os resultados!!!");
            }
        }

        public void ResultadosCsv(String caminhoArquivo, Int64 tempoPreenchendo, Int64 tempoCaminhando)
        {
            StringBuilder sb = new StringBuilder();
            if (_inseriu)
            {
                //inicializando variaveis auxiliares em posição inválida.
                Int64 maxVal = -1;
                Int64 maxIndex = -1;

                sb.AppendLine("Numero do Tubo,Quantidade de bolinhas");

                for (Int64 i = 0; i < _nroTubos; i++)
                {
                    sb.AppendLine($"{i},{_tubos[i]._qtdBolas}");
                    if (_tubos[i]._qtdBolas > maxVal)
                    {
                        maxVal = _tubos[i]._qtdBolas;
                        maxIndex = i;
                    }
                }

                sb.AppendLine("\n\n\n");
                sb.AppendLine($"Tubo com maior quantidade de bolinhas: {maxIndex},Quantidade:{maxVal}");
                sb.AppendLine($"Tempo de leitura do arquivo e preenchimento das listas: {tempoPreenchendo} ms");
                sb.AppendLine($"Tempo de busca das saidas para cada tubo: {tempoCaminhando} ms");

                FileOperations.GravarArquivo(sb.ToString(), caminhoArquivo);
            }
            else
            {
                Console.WriteLine("Você deve executar primeiro a inserção, para depois coletar os resultados!!!");
            }
        }

        /// <summary>Insere uma bolinha em cada tubo do sistema da Maquina.</summary>
        /// <returns>Variavel de controle para sucesso / fracasso</returns>
        public void InsereTodasBolinhas()
        {
            try
            {
                //percorre toda lista de tubos inserindo uma bolinha em cada.
                for (Int64 i = 0; i < _nroTubos; i++)
                {
                    InsereBolinha(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _inseriu = true;
            }
        }

        /// <summary>
        ///     Insere uma bolinha em UM tubo, mandado por parametro pelo outro metodo
        ///     ao final da execucao,  a bolinha estará no tubo por onde saiu.
        /// </summary>
        /// <param name="nroTb">Numero do tubo em que está sendo inserida a bolinha.</param>
        private void InsereBolinha(Int64 nroTb)
        {
            try
            {
                //começa na altura zero
                Int64 h = 0;
                //variavel auxiliar para o numero do tubo
                Int64 nroTbAtual = nroTb;
                //chamar metodo de procurar Conexão em Tubo
                Destino busca;
                do
                {
                    busca = _tubos[nroTbAtual].ProcuraConexao(h);
                    h = busca.altura;
                    //se a validação for tipo Fim, significa que já saiu do tubo, então não mudamos a variável nroTuboAtual
                    //para nao colocara qtdBolas em um valor invalido
                    if (busca.Valida() != Validacao.Fim)
                    {
                        nroTbAtual = busca.tuboDestino;
                    }
                } while (busca.Valida() == Validacao.Desvio);

                //ao fim da execução, verifica se foi erro
                if (busca.Valida() == Validacao.Erro)
                {
                    Console.WriteLine("ERRO EM UMA INSERÇÂO");
                    return;
                }

                //incrementa a quantidade de bolinhas no tubo final.
                _tubos[nroTbAtual]._qtdBolas++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}