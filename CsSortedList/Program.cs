using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaqTubosCs
{
    class Program
    {
        private const String Root = @"../../../data/";
        private static String filename = "caso1.txt"; //editar o nome aqui para outros testes
        static void Main(string[] args)
        {
            try
            {
                //concatena a pasta do diretorio do projeto com o nome do arquivo
                String fullpath = String.Concat(Root, filename);

                //lê o documento em linhas, para facilitar atribuição posterior
                String[] docLines = File.ReadAllLines(fullpath);

                String[] leituraPrincipal = docLines[0].Split(" ");

                long nroTubos = Convert.ToInt64(leituraPrincipal[0]);
                long altura = Convert.ToInt64(leituraPrincipal[1]);

                //instancia a maquina com a quantidade de tubos e altura lida no documento.
                MaquinaTubos maquina = new MaquinaTubos(nroTubos, altura);
                
                //roda o documento de texto a partir da linha 2 lendo as conexões presentes e enviando para a maquina
                for (long i = 1; i<docLines.Length; i++)
                {

                    //separa os valores pelos espaços 'a b c d'
                    String[] dados = docLines[i].Split(" ");
                    //o primeiro é a
                    long tb = Convert.ToInt64(dados[0]);
                    //o segundo espaço é  b
                    long h = Convert.ToInt64(dados[1]);
                    //o terceiro espaço é c
                    long tbD = Convert.ToInt64(dados[2]);
                    //o quarto espaço é d
                    long hD = Convert.ToInt64(dados[3]);
                    maquina.InsereConexao(tb, h, tbD, hD);
                }

                Console.WriteLine("sucesos ate aqui");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
