namespace GestaoEquipamentos.ConsoleApp
{
    public class Equipamentos
    {
        public string nome;
        public decimal precoAquisicao;
        public string numeroSerie;
        public string dataFabricacao;
        public string fabricante;
        public ListaEquipamentos[] historico = new ListaEquipamentos[100];
        public int equipamentosCadastrados = 0;


        public void CadastrarEquipamento()
        {
            Console.Write("Digite o nome do equipamento: ");
            nome = Console.ReadLine();

            Console.Write("Digite o preço de aquisição: ");
            precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série: ");
            numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação: ");
            dataFabricacao = Console.ReadLine();

            Console.Write("Digite o nome do fabricante: ");
            fabricante = Console.ReadLine();

            int novoId = GeradorId.GerarNovoIdConta();

            ListaEquipamentos lista = new ListaEquipamentos();
            lista.id = novoId;
            lista.nome = nome;
            lista.precoAquisicao = precoAquisicao;
            lista.numeroSerie = numeroSerie;
            lista.dataFabricacao = dataFabricacao;
            lista.fabricante = fabricante;
            historico[equipamentosCadastrados] = lista;
            equipamentosCadastrados++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Equipamento cadastrado com sucesso!");
            Console.ResetColor();

        }

        public string ListarEquipamentos()
        {
            string lista = "";
            Console.WriteLine("=========================================================== LISTA ===========================================================");
            Console.WriteLine("|Id   |Nome              |Preço Aquisição             |Número de Série             |Data de Fabricação          |Fabricante");
            for (int i = 0; i < 100; i++)
            {
                if (historico[i] != null)
                {
                    lista += $"{historico[i].Lista()}";
                }
            }
            return lista;
        }

        public void DeletarEquipamento()
        {
            Console.Write("Digite o ID do equipamento que deseja deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            if (idParaDeletar >= 0 && idParaDeletar < historico.Length)
            {
                for (int i = 0; i < equipamentosCadastrados; i++)
                {
                    if (historico[i].id == idParaDeletar)
                    {
                        historico[i] = null;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Equipamento deletado com sucesso!");
                        Console.ResetColor();
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Equipamento não encontrado!");
            }
        }

        public void EditarEquipamento()
        {
            Console.Write("Digite o ID do equipamento que deseja editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < equipamentosCadastrados; i++)
            {
                if (historico[i]?.id == idParaEditar)
                {
                    Console.WriteLine("Equipamento encontrado. Insira os novos dados:");

                    Console.Write("Novo nome: ");
                    string novoNome = Console.ReadLine();
                    historico[i].nome = novoNome;

                    Console.Write("Novo preço de aquisição: ");
                    decimal novoPreco = Convert.ToDecimal(Console.ReadLine());
                    historico[i].precoAquisicao = novoPreco;

                    Console.Write("Novo número de série: ");
                    string novoNumeroSerie = Console.ReadLine();
                    historico[i].numeroSerie = novoNumeroSerie;

                    Console.Write("Nova data de fabricação: ");
                    string novaDataFabricacao = Console.ReadLine();
                    historico[i].dataFabricacao = novaDataFabricacao;

                    Console.Write("Novo fabricante: ");
                    string novoFabricante = Console.ReadLine();
                    historico[i].fabricante = novoFabricante;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Equipamento editado com sucesso!");
                    Console.ResetColor();
                    return;
                }
            }

            Console.WriteLine("Equipamento não encontrado!");
        }

        public static class GeradorId
        {
            private static int equipamentosCadastrados = 0;

            public static int GerarNovoIdConta()
            {
                return ++equipamentosCadastrados;
            }
        }
    }
}
