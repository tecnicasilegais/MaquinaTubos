using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsStruct
{
    public class Leitor
    {
        public static string[] lerArquivo(string strArquivo)
        {
            return File.ReadAllLines(strArquivo);
        }
    }
}