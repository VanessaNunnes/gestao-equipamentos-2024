namespace GestaoEquipamentos.ConsoleApp
{
    public class Equipamentos
    {
        public string nome;
        public decimal precoAquisicao;
        public string numeroSerie;
        public DateTime dataFabricacao;
        public string fabricante;
        public ListaEquipamentos[] historico = new ListaEquipamentos[100];
        public int equipamentosCadastrados = 0;


        public void CadastrarEquipamento()
        {

            Console.Clear();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|       Gestão de Equipamentos       |");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            nome = Console.ReadLine();

            Console.Write("Digite o preço de aquisição: R$ ");
            precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série: ");
            numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação: ");
            dataFabricacao = Convert.ToDateTime(Console.ReadLine());

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
            Console.Clear();

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                 Gestão de Equipamentos                                          |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            Console.WriteLine();

            string lista = "";
            Console.WriteLine("============================================= LISTA =============================================");
            Console.WriteLine("|{0, -5} | {1, -15} | {2, -15} | {3, -18} | {4, -15} | {5, -15}",
                               "Id", "Nome", "Preço", "Número de Série", "Data Fabricação", "Fabricante" );

            for (int i = 0; i < 100; i++)
            {
                if (historico[i] != null)
                {
                    ListaEquipamentos equipamento = historico[i];
                    lista += $"|{equipamento.id,-5} | {equipamento.nome,-15} | {equipamento.precoAquisicao,-15} | {equipamento.numeroSerie,-18} | {equipamento.dataFabricacao.ToShortDateString(),-15} | {equipamento.fabricante, -15}\n";
                }
            }
            return lista; 
        }

        public void DeletarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|       Gestão de Equipamentos       |");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();

            Console.WriteLine("================== DELETAR ==================");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Equipamento não encontrado!");
                Console.ResetColor();
            }
        }

        public void EditarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|       Gestão de Equipamentos       |");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();

            Console.WriteLine("================== EDITAR ==================");

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
                    DateTime novaDataFabricacao = Convert.ToDateTime(Console.ReadLine());
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
