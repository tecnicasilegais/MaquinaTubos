using System;
using System.IO;

namespace MaqTubosCs
{
    public static class FileOperations
    {
        public static String[] TxtParaArrayString(String caminho)
        {
            //lê o documento em linhas, para facilitar atribuição posterior
            return File.ReadAllLines(caminho);
        }

        public static async void GravarArquivo(String conteudo, String caminho)
        {
            await using StreamWriter arquivo = new StreamWriter(caminho);
            await arquivo.WriteAsync(conteudo);
        }
    }
}