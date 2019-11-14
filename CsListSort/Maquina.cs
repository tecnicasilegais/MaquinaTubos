using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CsStruct
{
    public class Maquina
    {
        public List<Nodo> caminhos;

        public Maquina(string strArquivo)
        {
            caminhos = StringArrayToNodeList(strArquivo);
        }

        private List<Nodo> StringArrayToNodeList(string strArquivo)
        {
            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            List<Nodo> lista = new List<Nodo>();
            string[] listaLinhas = Leitor.lerArquivo(strArquivo);

            foreach (string linha in listaLinhas)
            {
                string[] numeros = linha.Split(' ');
                if (numeros.Length >= 4)
                {
                    lista.Add(new Nodo(
                        int.Parse(numeros[0]),
                        int.Parse(numeros[1]),
                        int.Parse(numeros[2]),
                        int.Parse(numeros[3])
                    ));
                }
            }

            long leitura = watch.ElapsedMilliseconds;
            Console.WriteLine($"Leitura: {leitura}ms");

            lista.Sort();

            watch.Stop();
            long ordenacao = watch.ElapsedMilliseconds;
            Console.WriteLine($"Ordenacao: {ordenacao - leitura}ms");
            Console.WriteLine($"Total:{ordenacao}ms");
            return lista;
        }
    }
}