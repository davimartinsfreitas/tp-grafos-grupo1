using System.Text;
using tp_grafos.LeituraArquivo;
using tp_grafos.RepresentacaoGrafos.Algoritmos;

namespace tp_grafos.RepresentacaoGrafos
{
    public class OperacoesGrafos
    {
        private static IRepresentacaoGrafos? grafo;

        public static IRepresentacaoGrafos ObterGrafo()
        {
            if (grafo == null)
            {
                throw new ArgumentException("O grafo ainda não foi criado ou lido.\n");
            }
            return grafo;
        }

        public static void CriarEImprimirGrafo()
        {
            Console.WriteLine("Digite o número de vértices:");
            int vertices = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o número de arestas:");
            int arestas = Convert.ToInt32(Console.ReadLine());

            double densidade = arestas / (vertices * (vertices - 1.0));

            Console.WriteLine($"Densidade do grafo: {densidade:F2}");

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

            for (int i = 0; i < arestas; i++)
            {
                Console.WriteLine($"Digite a aresta {i + 1} (origem destino peso):");
                string[] entrada = Console.ReadLine().Split(' ');
                int origem = Convert.ToInt32(entrada[0]);
                int destino = Convert.ToInt32(entrada[1]);
                double peso = Convert.ToDouble(entrada[2]);

                origem--;
                destino--;

                grafo.AdicionarAresta(origem, destino, peso);
            }
            grafo.Imprimir();
        }


        public static string ExecutarDijkstra()
        {
            try{
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("Digite o nó que deseja iniciar a interação: ");
                int raiz = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o destino que deseja ter a interação: ");
                int destino = Convert.ToInt32(Console.ReadLine());

                Dijkstra dijkstra = new Dijkstra(raiz, destino, grafo);
                dijkstra.ExecultarMetodo();
                return dijkstra.imprimir();
            }catch(ArgumentException ex)
            {
                return ex.Message;
            }
        }

        public static string ExercutarFloyd()
        {
            try
            {
                ObterGrafo();
                ImprimirGrafo();
                Floyd_Warshall floyd_Warshall = new Floyd_Warshall(grafo);
                floyd_Warshall.execultarFloyd();
                return floyd_Warshall.ImprimirMenorCaminho();
            }catch(ArgumentException ex)
            {
                return ex.Message;
            }
        }

        public static void ImprimirGrafo()
        {
            if (grafo != null)
            {
                grafo.Imprimir();
            }
        }

        public static void LerGrafoFormatoDimacs()
        {
            LeitorDimacs leitorDimacs = new LeitorDimacs();
            string arquivo = Path.Combine(Directory.GetCurrentDirectory(), "example_graph.txt");
            grafo = leitorDimacs.ParseToRepresentacaoGrafo(arquivo);
        }

        public static string ImprimirArestasAdjacentes()
        {
            string retorno = "";
            try
            {
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("\nInforme a aresta da qual deseja saber as arestas adjacentes, no formato a seguir:");
                Console.WriteLine("Informe o vértice de origem da aresta:");
                int origem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o vértice de destino da aresta:");
                int destino = Convert.ToInt32(Console.ReadLine());

                try
                {
                    retorno = grafo.ObterArestasAdjacentes(origem, destino);
                }
                catch (ArgumentException ex)
                {
                    retorno = ex.Message;
                }
            }catch(ArgumentException ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public static string ImprimirVerticesAdjacentes()
        {
            string retorno = "";
            try
            {
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("Informe o vértice para o qual deseja saber os vértices adjacentes:");
                int vertice = Convert.ToInt32(Console.ReadLine());

                retorno = "\nVértices adjacentes a " + vertice + ":\n";
                Dictionary<string, StringBuilder> adjacencias = new Dictionary<string, StringBuilder>();
                try
                {
                    adjacencias = grafo.ObterVerticesAdjacentes(vertice);
                    retorno += adjacencias["sucessores"].ToString() + adjacencias["predecessores"].ToString();
                }
                catch (ArgumentException ex)
                {
                    retorno = ex.Message;
                }
            }catch(ArgumentException ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }

        public static string ImprimirArestasIncidentes()
        {
            string retorno = "";
            try
            {
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("Informe o vértice para o qual deseja saber as arestas incidentes:");
                int vertice = Convert.ToInt32(Console.ReadLine());

                retorno = "\nArestas incidentes a " + vertice + ":\n";

                try
                {
                    retorno += grafo.ObterArestasIncidentes(vertice);
                }
                catch (ArgumentException ex)
                {
                    retorno = ex.Message;
                }
                
            }catch(ArgumentException ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }

        public static string ImprimirVerticesIncidentesEmAresta()
        {
            string retorno = "";

            try{
                ObterGrafo();
                ImprimirGrafo();
                Console.WriteLine("\nInforme a aresta da qual deseja saber os vértices incidentes, no formato a seguir:");
                Console.WriteLine("Informe o vértice de origem da aresta");
                int origem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o vértice de destino da aresta");
                int destino = Convert.ToInt32(Console.ReadLine());

                retorno = "\nVertices incidentes a aresta informada:\n";
                try
                {
                    retorno += grafo.ObterVerticesIncidentesAAresta(origem, destino);
                }
                catch (ArgumentException ex)
                {
                    retorno = ex.Message;
                }
            }catch(ArgumentException ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }

        public static string ImprimirGrauVertice()
        {
            string retorno = "";

            try{
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("\nInforme o vértice que deseja saber o grau:");
                int vertice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    string grauEntrada = $"\nGrau de entrada do vértice {vertice}: " + grafo.ObterGrauEntradaVertice(vertice);
                    string grauSaida = $"\nGrau de saída do vértice {vertice}: " + grafo.ObterGrauSaidaVertice(vertice);
                    retorno += grauEntrada;
                    retorno += grauSaida;
                }
                catch (ArgumentException ex)
                {
                    retorno = ex.Message;
                }       
            }catch(ArgumentException ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }

        public static string VerificarVerticesAdjacentes()
        {
            string retorno = "";
            try
            {
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("\nInforme os vértices que deseja saber se são adjacentes");
                Console.WriteLine("Vértice v:");
                int vertice1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Vértice w:");
                int vertice2 = Convert.ToInt32(Console.ReadLine());

                retorno = "";
                if (grafo.VerificarVerticesAdjacentes(vertice1, vertice2))
                {
                    retorno = "\nOs vértices são adjacentes!";
                }
                else
                {
                    retorno = "\nOs vértices não são adjacentes!";
                }                  
            }catch(ArgumentException ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }

        public static void SubstituirOPeso()
        {
            try
            {
                ObterGrafo();
                ImprimirGrafo();

                Console.WriteLine("Informe o vértice de origem da aresta");
                int origem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o vértice de destino da aresta");
                int destino = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o novo peso: ");
                double peso = Convert.ToDouble(Console.ReadLine());
                try
                {
                    grafo.SubstituirOPeso(peso, origem, destino);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }      
                ImprimirGrafo();              
            }catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void trocarVertice()
        {
            try
            {
                ObterGrafo();
                ImprimirGrafo();
                Console.WriteLine("Informe o vértice que deseja trocar no grafo:");
                int v1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe outro vértice que deseja trocar no grafo: ");
                int v2 = Convert.ToInt32(Console.ReadLine());
                try{
                    grafo.trocarVertice(v1,v2);
                    ImprimirGrafo();
                }catch(ArgumentException ex){
                    Console.WriteLine(ex.Message);  
                }                
            }catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExecutarBuscaEmLargura()
        {
            try
            {
                ObterGrafo();
                ImprimirGrafo();
                Console.WriteLine("Digite o vértice inicial para a busca em largura:");
                int inicioBFS = Convert.ToInt32(Console.ReadLine());
                var bfs = new BuscaEmLargura(OperacoesGrafos.ObterGrafo());
                Console.WriteLine(bfs.Executar(inicioBFS));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DesafioFerrovia()
        {
            try
            {
                Console.WriteLine("Insere aqui a matriz de distancias minimas: ");
                DesafioFerrovias desafioFerrovia = new DesafioFerrovias();
                desafioFerrovia.Executar();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExecutarBuscaEmProfundidade()
        {
            try
            {
                ObterGrafo();
                ImprimirGrafo();
                Console.WriteLine("Digite o vértice inicial para a busca em profundidade:");
                int raiz = Convert.ToInt32(Console.ReadLine());
                BuscaEmProfundidade buscaEmProfundidade = new BuscaEmProfundidade(raiz, grafo);
                buscaEmProfundidade.IniciarBusca();
                buscaEmProfundidade.Imprimir();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
