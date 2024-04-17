namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool opcaoSaidaEscolhida = false;
            while (!opcaoSaidaEscolhida)
            {
                Console.Clear();

                Console.WriteLine("--------------------------------------");
                Console.WriteLine("|       Gestão de Equipamentos       |");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine();

                Console.WriteLine("1 - Gerência de Equipamentos");
                Console.WriteLine("2 - Controle de Chamados");
                Console.WriteLine("3 - Sair");

                Console.WriteLine();

                Console.Write("Escolha uma das opções: ");
                char opcaoEscolhida = Console.ReadLine()[0];

                switch (opcaoEscolhida)
                {
                    case '1':
                        GerenciarEquipamentos();
                        break;
                    case '2':
                        GerenciarChamados();
                        break;
                    default:
                        opcaoSaidaEscolhida = true;
                        break;
                }
            }
            Console.ReadLine();

        }
        static void GerenciarEquipamentos()
        {
            Equipamentos equipamentos = new Equipamentos();

            bool opcaoSaidaEscolhida = false;
            while (!opcaoSaidaEscolhida)
            {
                Console.Clear();

                Console.WriteLine("--------------------------------------");
                Console.WriteLine("|       Gestão de Equipamentos       |");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para Visualizar Equipamentos");
                Console.WriteLine("Digite 3 para Editar um Equipamento");
                Console.WriteLine("Digite 4 para Deletar um Equipamento");
                Console.WriteLine("Digite S para voltar");

                Console.WriteLine();

                Console.Write("Escolha uma das opções: ");
                char operacao = Convert.ToChar(Console.ReadLine());

                switch (operacao)
                {
                    case '1':
                        equipamentos.CadastrarEquipamento();
                        break;
                    case '2':
                        Console.WriteLine(equipamentos.ListarEquipamentos());
                        break;
                    case '3':
                        equipamentos.EditarEquipamento();
                        break;
                    case '4':
                        equipamentos.DeletarEquipamento();
                        break;
                    default:
                        opcaoSaidaEscolhida = true;
                        break;
                }
                Console.ReadLine();
            }
        }


        static void GerenciarChamados()
        {

        }
    }
}



    
