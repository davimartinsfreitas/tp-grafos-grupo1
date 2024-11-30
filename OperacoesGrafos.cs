using System;
using System.IO;
using tp_grafos.LeituraArquivo;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class OperacoesGrafos
    {
        private static IRepresentacaoGrafos grafo;

        public static void CriarEImprimirGrafo()
        {
            Console.WriteLine("Digite o número de vértices:");
            int vertices = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o número de arestas:");
            int arestas = Convert.ToInt32(Console.ReadLine());

            // Calcula a densidade do grafo
            double densidade = (2.0 * arestas) / (vertices * (vertices - 1));

            Console.WriteLine($"Densidade do grafo: {densidade:F2}");

            // representação com base na densidade
            if (densidade > 0.5)
            {
                Console.WriteLine("Representação escolhida: Matriz de Adjacência");
                grafo = new MatrizAdjacencia(vertices);
            }
            else
            {
                Console.WriteLine("Representação escolhida: Lista de Adjacência");
                grafo = new ListaAdjacencia(vertices);
            }

            // Leitura das arestas e construção do grafo
            for (int i = 0; i < arestas; i++)
            {
                Console.WriteLine($"Digite a aresta {i + 1} (origem destino peso):");
                string[] entrada = Console.ReadLine().Split(' ');
                int origem = Convert.ToInt32(entrada[0]);
                int destino = Convert.ToInt32(entrada[1]);
                int peso = Convert.ToInt32(entrada[2]);

                grafo.AdicionarAresta(origem, destino, peso);
            }

            // Imprime o grafo na representação escolhida
            grafo.Imprimir();
        }

        public static void LerGrafoFormatoDimacs()
        {
            LeitorDimacs leitorDimacs = new LeitorDimacs();
            string arquivo = Path.Combine(Directory.GetCurrentDirectory(), "example_graph.txt");

            grafo = leitorDimacs.ParseToRepresentacaoGrafo(arquivo);

            if (grafo != null)
            {
                grafo.Imprimir();
            }
        }

        public static string ImprimirArestasAdjacentes()
        {
            if (grafo == null)
            {
                LerGrafoFormatoDimacs();
            }

            Console.WriteLine("\nInforme a aresta da qual deseja saber as arestas adjacente, no formato a seguir:");
            Console.WriteLine("Informe o vértice de origem da aresta");
            int origem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o vértice de destino da aresta");
            int destino = Convert.ToInt32(Console.ReadLine());

            string retorno = "";
            try
            {
                retorno = grafo.ObterArestasAdjacentes(origem, destino);
            }
            catch (ArgumentException ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }
    }
}
