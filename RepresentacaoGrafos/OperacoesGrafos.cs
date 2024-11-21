using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace tp_grafos.RepresentacaoGrafos
{
    internal class OperacoesGrafos
    {
        public static void CriarEImprimirGrafo()
        {
            Console.WriteLine("Digite o número de vértices:");
            int vertices = int.Parse(Console.ReadLine());
 
            Console.WriteLine("Digite o número de arestas:");
            int arestas = int.Parse(Console.ReadLine());
 
            Console.WriteLine("Escolha a representação (1 - Lista de Adjacência, 2 - Matriz de Adjacência):");
            int opcao = int.Parse(Console.ReadLine());
 
            if (opcao == 1)
            {
                var grafo = new ListaAdjacencia(vertices);
                for (int i = 0; i < arestas; i++)
                {
                    Console.WriteLine($"Digite a aresta {i + 1} (origem destino peso):");
                    string[] entrada = Console.ReadLine().Split(' ');
                    int origem = int.Parse(entrada[0]);
                    int destino = int.Parse(entrada[1]);
                    int peso = int.Parse(entrada[2]);
 
                    grafo.AdicionarAresta(origem, destino, peso);
                }
 
                grafo.Imprimir();
            }
            else if (opcao == 2)
            {
                var grafo = new MatrizAdjacencia(vertices);
                for (int i = 0; i < arestas; i++)
                {
                    Console.WriteLine($"Digite a aresta {i + 1} (origem destino peso):");
                    string[] entrada = Console.ReadLine().Split(' ');
                    int origem = int.Parse(entrada[0]);
                    int destino = int.Parse(entrada[1]);
                    int peso = int.Parse(entrada[2]);
 
                    grafo.AdicionarAresta(origem, destino, peso);
                }
 
                grafo.Imprimir();
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}
 
 
 