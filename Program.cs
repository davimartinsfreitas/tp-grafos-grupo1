using System.Text;
using tp_grafos.Menu;
using tp_grafos.RepresentacaoGrafos;

namespace tp_grafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OpcoesMenu opcaoUsuario;
            int opcaoAux;

            do
            {
                Console.WriteLine(exibeMenu());
                opcaoAux = lerNumero();
                opcaoUsuario = (OpcoesMenu)opcaoAux - 1;
                processarMenu(opcaoUsuario);
            } while (opcaoUsuario != OpcoesMenu.SAIR);
        }

        public static void processarMenu(OpcoesMenu opcaoUsuario)
        {
            Console.Clear();
            Console.WriteLine(cabecalho());
            switch (opcaoUsuario)
            {
                case OpcoesMenu.CRIAR_GRAFO:
                    OperacoesGrafos.CriarEImprimirGrafo();
                    break;
                case OpcoesMenu.LER_GRAFO_DIMACS:
                    OperacoesGrafos.LerGrafoFormatoDimacs();
                    break;
                case OpcoesMenu.IMPRIMIR_ARESTAS_ADJACENTES:
                    Console.WriteLine(OperacoesGrafos.ImprimirArestasAdjacentes());
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

            if (opcaoUsuario != OpcoesMenu.SAIR)
                espera();
        }

        public static void espera()
        {
            Console.WriteLine("Digite Enter para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        public static int lerNumero()
        {
            int opcaoAux;
            bool convertido = false;
            do
            {
                convertido = int.TryParse(Console.ReadLine(), out opcaoAux);
                if (!convertido)
                    Console.WriteLine("Não é um número. Digite novamente");
            } while (!convertido);

            return opcaoAux;
        }


        public static String exibeMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine(cabecalho());
            int index = 1;
            menu.AppendLine($"{index++}. Criar grafo e imprimi-lo");
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
            menu.AppendLine($"{index++}. Executar algoritmo de Dijkstra");
            menu.AppendLine($"{index++}. Executar algoritmo de Floyd Warshall");
            menu.AppendLine($"{index++}. Desafio - Ferrovias");
            menu.AppendLine($"\n{index++}. Sair");
            menu.AppendLine("\nEscolha uma opção");

            return menu.ToString();
        }

        public static string cabecalho()
        {
            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine("-----------------------------------------");
            cabecalho.AppendLine("              Grupo 01");
            cabecalho.AppendLine("-----------------------------------------");
            return cabecalho.ToString();
        }

    }


}