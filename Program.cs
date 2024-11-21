using System.Text;
using tp_grafos.Menu;

namespace tp_grafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OpcoesMenu opcaoUsuario;

            do
            {
                Console.WriteLine(exibeMenu());
                opcaoUsuario = (OpcoesMenu) int.Parse(Console.ReadLine());
                processarMenu(opcaoUsuario);
            } while (opcaoUsuario != OpcoesMenu.SAIR);
        }


        public static String exibeMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("\n=====Parte 1======");
            int index = 1;
            menu.AppendLine($"{index++}. Criar grafo e imprimi-lo");
            menu.AppendLine("\n=====Parte 2======");
            menu.AppendLine($"{index++}. Ler grafo no formato DIMACS");
            menu.AppendLine($"{index++}. Imprimir Arestas Adjacentes a uma aresta");
            menu.AppendLine($"{index++}. Imprimir Vértices Adjacentes a um vértice");
            menu.AppendLine($"{index++}. Imprimir Arestas Incidentes a um vértice");
            menu.AppendLine($"{index++}. Imprimir Vértices Incidentes a uma aresta");
            menu.AppendLine($"{index++}. Verificar se dois vértices são adjacentes");
            menu.AppendLine($"{index++}. Substitituir peso de uma aresta");
            menu.AppendLine($"{index++}. Trocar dois vértices");
            menu.AppendLine($"{index++}. Executar busca em largura");
            menu.AppendLine($"{index++}. Executar busca em profundidade");
            menu.AppendLine($"{index++}. Executar algoritmo de Dikstra");
            menu.AppendLine($"{index++}. Executar algoritmo de Floyd Warshall");

            menu.AppendLine("\n=====Parte 3======");
            menu.AppendLine($"{index++}. Desafio - Ferrovias");

            menu.AppendLine($"\n{index++}. Sair");

            menu.AppendLine("\nEscolha uma opção");

            return menu.ToString();
        }

        public static void processarMenu(OpcoesMenu opcaoUsuario)
        {
            switch (opcaoUsuario)
            {
                case OpcoesMenu.CRIAR_GRAFO:
                    break;
                case OpcoesMenu.LER_GRAFO_DIMACS:
                    break;
                case OpcoesMenu.IMPRIMIR_ARESTAS_ADJACENTES:
                    break;
                case OpcoesMenu.IMPRIMIR_VERTICES_ADJACENTES:
                    break;
                case OpcoesMenu.IMPRIMIR_ARESTAS_INCIDENTES_A_VERTICE:
                    break;
                case OpcoesMenu.IMPRIMIR_VERTICES_INCIDENTES_A_ARESTA:
                    break;
                case OpcoesMenu.VERIFICAR_VERTICES_ADJACENTES:
                    break;
                case OpcoesMenu.SUBSTITUIR_PESO_ARESTA:
                    break;
                case OpcoesMenu.TROCAR_VERTICES:
                    break;
                case OpcoesMenu.BUSCA_EM_LARGURA:
                    break;
                case OpcoesMenu.BUSCA_EM_PROFUNDIDADE:
                    break;
                case OpcoesMenu.CAMINHO_MINIMO_DIJKSTRA:
                    break;
                case OpcoesMenu.CAMINHO_MINIMO_FLOYD_WARSHALL:
                    break;
                case OpcoesMenu.DESAFIO_FERROVIAS:
                    break;
                case OpcoesMenu.SAIR:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
          
        }
    }


}
