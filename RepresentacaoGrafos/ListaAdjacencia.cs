using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class ListaAdjacencia
    {
          private Dictionary<int, List<(int, int)>> lista;   

        public ListaAdjacencia(int vertices)
        {
            lista = new Dictionary<int, List<(int, int)>>();
            for (int i = 0; i < vertices; i++)
            {
                lista[i] = new List<(int, int)>();
            }
        }
 
        public void AdicionarAresta(int origem, int destino, int peso)
        {
            lista[origem].Add((destino, peso));
        }
 
        public void Imprimir()
        {
            Console.WriteLine("Lista de Adjacência:");
            foreach (var vertice in lista)
            {
                Console.Write($"{vertice.Key}: ");
                foreach (var aresta in vertice.Value)
                {
                    Console.Write($"({aresta.Item1}, {aresta.Item2}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
    