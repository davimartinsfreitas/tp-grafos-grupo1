using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos
{
    interface IRepresentacaoGrafos
    {
        public abstract void AdicionarAresta(int origem, int destino, int peso);

        public abstract void Imprimir();

        public abstract string ObterArestasAdjacentes(int origem, int destino);

        public abstract bool IsArestaExistente(int origem, int destino);
    }
}
    