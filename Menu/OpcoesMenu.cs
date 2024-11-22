using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.Menu
{
    public enum OpcoesMenu
    {
      CRIAR_GRAFO,
      LER_GRAFO_DIMACS,
      IMPRIMIR_ARESTAS_ADJACENTES,
      IMPRIMIR_VERTICES_ADJACENTES,
      IMPRIMIR_ARESTAS_INCIDENTES_A_VERTICE,
      IMPRIMIR_VERTICES_INCIDENTES_A_ARESTA,
      VERIFICAR_VERTICES_ADJACENTES,
      SUBSTITUIR_PESO_ARESTA,
      TROCAR_VERTICES,
      BUSCA_EM_LARGURA,
      BUSCA_EM_PROFUNDIDADE,
      CAMINHO_MINIMO_DIJKSTRA,
      CAMINHO_MINIMO_FLOYD_WARSHALL,
      DESAFIO_FERROVIAS,
      SAIR
    }
}
