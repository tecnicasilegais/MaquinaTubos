using System;

namespace CsStruct
{
    public class Nodo : IComparable<Nodo>
    {
        public int CanoOrigem { get; }

        public int AlturaOrigem { get; }

        public int CanoDestino { get; }

        public int AlturaDestino { get; }

        public Nodo(int canoOrigem, int alturaOrigem, int canoDestino, int alturaDestino)
        {
            this.CanoOrigem = canoOrigem;
            this.AlturaOrigem = alturaOrigem;
            this.CanoDestino = canoDestino;
            this.AlturaDestino = alturaDestino;
        }


        public int CompareTo(Nodo other)
        {
            int resultado = CanoOrigem.CompareTo(other.CanoOrigem);
            if (resultado != 0) { return resultado; }

            resultado = AlturaOrigem.CompareTo(other.AlturaOrigem);
            if (resultado != 0) { return resultado; }

            resultado = CanoDestino.CompareTo(other.CanoDestino);
            return resultado != 0 ? resultado : AlturaDestino.CompareTo(other.AlturaDestino);
        }
    }
}