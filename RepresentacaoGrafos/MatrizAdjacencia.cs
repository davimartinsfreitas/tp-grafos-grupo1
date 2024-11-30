using System;
using System.Collections.Generic;
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
            matriz[destino, origem] = peso; // Caso seja um grafo não direcionado
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
                if(i!= destinoAux && matriz[origemAux, i] > 0){
                    arestasAdjacentes += "(" + origem + "," + (i+1) + ")\n";
                }

                if(matriz[i, origemAux] > 0){
                    arestasAdjacentes += "(" + (i+1) + "," + origem + ")\n";
                }

                if(i!= origemAux && matriz[i, destinoAux] > 0){
                    arestasAdjacentes += "(" + (i+1) + "," + destino + ")\n";
                }

                if(matriz[destinoAux, i] > 0){
                    arestasAdjacentes += "(" + destino + "," + (i+1) + ")\n";
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
    }
}

