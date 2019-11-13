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
                String fullpath = String.Concat(Root, filename);

                //lê o documento em linhas, para facilitar atribuição posterior
                String[] docLines = File.ReadAllLines(fullpath);

                MaquinaTubos maquina = new MaquinaTubos(3,5);
                maquina.testar(2);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
