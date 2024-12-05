using System.Text;

namespace tp_grafos.RepresentacaoGrafos
{
    interface IRepresentacaoGrafos
    {
        public abstract void AdicionarAresta(int origem, int destino, int peso);

        public abstract void Imprimir();

        public abstract string ObterArestasAdjacentes(int origem, int destino);

        public abstract bool IsArestaExistente(int origem, int destino);

        public abstract Dictionary<string, StringBuilder> ObterVerticesAdjacentes(int vertice);

        public abstract string ObterArestasIncidentes(int vertice);

        public abstract string ObterVerticesIncidentesAAresta(int origem, int destino);

        public abstract bool VerificarVerticesAdjacentes(int origem, int destino);

        public abstract int ObterGrauEntradaVertice(int vertice);

        public abstract int ObterGrauSaidaVertice(int vertice);
    }
}
    