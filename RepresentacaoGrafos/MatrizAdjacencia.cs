using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class MatrizAdjacencia : IRepresentacaoGrafos
    {
        private int[,] matriz;

        public MatrizAdjacencia(int vertices)
        {
            matriz = new int[vertices, vertices];
        }

        public void AdicionarAresta(int origem, int destino, int peso)
        {
            matriz[origem, destino] = peso;
        }

        public void Imprimir()
        {
            Console.WriteLine("Matriz de Adjacência:");
            int tamanho = matriz.GetLength(0);
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    Console.Write($"{matriz[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public string ObterArestasAdjacentes(int origem, int destino){
            string arestasAdjacentes = "\nArestas Adjacentes a aresta (" + origem + "," + destino + "):\n";
            
            int tamanho = matriz.GetLength(0);
            int origemAux = origem-1;
            int destinoAux = destino-1;

            if(!IsArestaExistente(origemAux, destinoAux)){
                throw new ArgumentException("A aresta informada não existe no grafo!");
            }
            
            for (int i = 0; i < tamanho; i++)
            {
                if(i!= destinoAux && matriz[origemAux, i] > 0)
                {
                    // Arestas que saem do vértice de origem
                    arestasAdjacentes += $"({origem},{i+1},{matriz[origemAux, i]})\n";
                }
                else if(matriz[i, origemAux] > 0)
                {
                    // Arestas que chegam no vértice de origem
                    arestasAdjacentes += $"({i+1},{origem},{matriz[i, origemAux]})\n";   
                }
                else if(i!= origemAux && matriz[i, destinoAux] > 0)
                {
                    // Arestas que chegam no vértice de destino
                    arestasAdjacentes += $"({i+1},{destino},{matriz[i, destinoAux]})\n";
                }
                else if(matriz[destinoAux, i] > 0)
                {
                    // Arestas que saem no vértice de destino
                    arestasAdjacentes += $"({destino},{i+1},{matriz[destinoAux, i]})\n";
                }
            }
            return arestasAdjacentes;
        }

        public bool IsArestaExistente(int origem, int destino)
        {
            return origem >= 0 && origem < matriz.GetLength(0)
                && destino >= 0 && destino < matriz.GetLength(1)
                && matriz[origem, destino] > 0;
        }

        public Dictionary<string, StringBuilder> ObterVerticesAdjacentes(int vertice)
        {
            int tamanho = matriz.GetLength(0);
            int indiceVertice = vertice-1;

            if(indiceVertice < 0 || indiceVertice >= tamanho){
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            Dictionary<string, StringBuilder> adjacencias = new Dictionary<string, StringBuilder>();
            StringBuilder sucessores = new StringBuilder("Sucessores:\n");
            StringBuilder predecessores = new StringBuilder("Predecessores:\n");

            for(int i = 0; i < tamanho; i++)
            {
                if(matriz[indiceVertice, i] > 0)
                {
                    sucessores.AppendLine((i+1).ToString());
                }
                
                if(matriz[i, indiceVertice] > 0)
                {
                    predecessores.AppendLine((i+1).ToString());
                }
            }
            adjacencias["sucessores"] = sucessores;
            adjacencias["predecessores"] = predecessores;
            return adjacencias;
        }
    }
}

