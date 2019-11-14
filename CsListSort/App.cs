using System;

namespace CsStruct
{
    public class App
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 8; i++)
            {
                Console.WriteLine("=== \t TESTE " + i + " \t ===");
                new Maquina("../input/caso" + i + ".txt");
                Console.WriteLine();
            }
        }
    }
}