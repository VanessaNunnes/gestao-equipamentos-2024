namespace GestaoEquipamentos.ConsoleApp
{
    public class ListaEquipamentos
    {
        public int id;
        public string nome;
        public decimal precoAquisicao;
        public string numeroSerie;
        public string dataFabricacao;
        public string fabricante;

        public string Lista()
        {
            return $"|{id}    |{nome}          |{precoAquisicao}                        |{numeroSerie}                     |{dataFabricacao}                  |{fabricante}\n";
        }
    }
}
