using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class ListaAdjacencia : IRepresentacaoGrafos
    {
          private Dictionary<int, List<(int, int)>> lista;

        public ListaAdjacencia(int vertices)
        {
            lista = new Dictionary<int, List<(int, int)>>();
            for (int i = 1; i <= vertices; i++)
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

        public string ObterArestasAdjacentes(int origem, int destino){
            if(!IsArestaExistente(origem, destino)){
                throw new ArgumentException("A aresta informada não existe no grafo!");
            }
            
            string arestasAdjacentes = "\nArestas Adjacentes a aresta (" + origem + "," + destino + "):\n";

            foreach(KeyValuePair<int, List<(int, int)>> adjacencias in lista)
            {
                foreach(var elemento in adjacencias.Value)
                {
                    bool sucessorComum = adjacencias.Key == destino;
                    bool predecessorComum = adjacencias.Key == origem && elemento.Item1 != destino;
                    bool sucessorOrigemOuDestino = elemento.Item1 == destino || elemento.Item1 == origem;
                    
                    if(adjacencias.Key == destino || (adjacencias.Key == origem && elemento.Item1 != destino)
                        || (elemento.Item1 == destino && adjacencias.Key != origem) || elemento.Item1 == origem)
                    {
                        arestasAdjacentes += "(" + adjacencias.Key + "," + elemento.Item1 + ")\n"; 
                    }
                }
            }

            return arestasAdjacentes;
        }

        public bool IsArestaExistente(int origem, int destino)
        {
            return lista.ContainsKey(origem) && lista[origem].Find(a => a.Item1 == destino) != (0, 0);
        }        
    }
}
    