using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class MatrizAdjacencia
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
    }
}

