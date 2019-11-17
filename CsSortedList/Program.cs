using System;
using System.Diagnostics;

namespace MaqTubosCs
{
    internal class Program
    {
        private const String Root = @"../../../../input/";
        private const String Extensao = ".txt";
        private static String _filename = "caso8"; //editar o nome aqui para outros testes
        private static Int64 _caminhamento;
        private static Int64 _preenchimento;

        private static void Main(String[] args)
        {
            try
            {
                Console.WriteLine("Digite o nome do arquivo a ser testado (sem extensão) (deve ser txt)");
                _filename = Console.ReadLine();

                String[] docLines = FileOperations.TxtParaArrayString(String.Concat(Root, _filename, Extensao));

                String[] leituraPrincipal = docLines[0].Split(' ');

                Int64 nroTubos = Convert.ToInt64(leituraPrincipal[0]);
                Int64 altura = Convert.ToInt64(leituraPrincipal[1]);

                //instancia a maquina com a quantidade de tubos e altura lida no documento.
                MaquinaTubos maquina = new MaquinaTubos(nroTubos, altura);

                //Calcula o tempo de execução da leitura e instanciação das conexões
                Stopwatch sw = Stopwatch.StartNew();
                //roda o documento de texto a partir da linha 2 lendo as conexões presentes e enviando para a maquina
                for (Int64 i = 1; i < docLines.LongLength; i++)
                {
                    //separa os valores pelos espaços 'a b c d'
                    String[] dados = docLines[i].Split(" ");
                    //o primeiro é a
                    Int64 tb = Convert.ToInt64(dados[0]);
                    //o segundo espaço é  b
                    Int64 h = Convert.ToInt64(dados[1]);
                    //o terceiro espaço é c
                    Int64 tbD = Convert.ToInt64(dados[2]);
                    //o quarto espaço é d
                    Int64 hD = Convert.ToInt64(dados[3]);
                    maquina.InsereConexao(tb, h, tbD, hD);
                }

                sw.Stop();
                _preenchimento = sw.ElapsedMilliseconds;

                sw = Stopwatch.StartNew();

                maquina.InsereTodasBolinhas();

                sw.Stop();
                _caminhamento = sw.ElapsedMilliseconds;

                //imprime os resultados no console do windows
                //maquina.ResultadosConsole();

                //imprime os resultados num CSV
                maquina.ResultadosCsv(String.Concat(Root, "solucao_", _filename, ".csv"),
                    _preenchimento, _caminhamento);
                Console.WriteLine("Pronto!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}