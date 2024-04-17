namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|       Gestão de Equipamentos       |");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerência de Equipamentos");
            Console.WriteLine("2 - Controle de Chamados");
            Console.WriteLine("3 - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            string opcaoEscolhida = Console.ReadLine();


            Equipamentos equipamentos = new Equipamentos();

            Console.WriteLine("Gestão de Equipamentos");

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para Visualizar Equipamentos");
                Console.WriteLine("Digite 3 para Editar um Equipamento");
                Console.WriteLine("Digite 4 para Deletar um Equipamento");
                Console.WriteLine("Digite 0 para sair");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        equipamentos.CadastrarEquipamento();
                        break;
                    case "2":
                        Console.WriteLine(equipamentos.ListarEquipamentos());
                        break;
                    case "3":
                        equipamentos.EditarEquipamento();
                        break;
                    case "4":
                        equipamentos.DeletarEquipamento();
                        break;
                    case "0":
                        continuar = false;
                        break;   
                }
            }
        }
    }
}
