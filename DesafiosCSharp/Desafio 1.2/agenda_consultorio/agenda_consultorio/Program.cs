class Program
{
    static void Main(string[] args) {

        int op_menu;

        do
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1 - Cadastrar novo paciente");
            Console.WriteLine("2 - Agenda");
            Console.WriteLine("3 - Fim");

            op_menu = int.Parse(Console.ReadLine());

            switch (op_menu)
            {
                case 1:
                    Console.WriteLine("Menu do Cadastro de Pacientes");
                    Console.WriteLine("1 - Cadastrar novo paciente");
                    Console.WriteLine("2 - Excluir paciente");
                    Console.WriteLine("3 - Listar pacientes (ordenado por CPF)");
                    Console.WriteLine("4 - Listar pacientes (ordenado por nome)");
                    Console.WriteLine("5 - Voltar p/ menu principal");

                    int op_cadastro = int.Parse(Console.ReadLine());

                    switch (op_cadastro)
                    {
                        case 1:
                            Console.WriteLine("Digite o CPF do paciente: ");
                            string cpf = Console.ReadLine();
                            Console.WriteLine("Digite o nome do paciente: ");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Digite a data de nascimento do paciente: ");
                            DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());
                            Console.WriteLine("Digite a idade do paciente: ");
                            int idade = int.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Digite o CPF do paciente que deseja excluir: ");
                            cpf = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Listagem de pacientes ordenados por CPF");
                            break;
                        case 4:
                            Console.WriteLine("Listagem de pacientes ordenados por nome");
                            break;
                        case 5:
                            Console.WriteLine("Voltando para o menu principal");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, voltando para o menu principal");
                            break;
                    }
                    break;

                case 2:
                    Console.WriteLine("Agenda");
                    Console.WriteLine("1 - Marcar consulta");
                    Console.WriteLine("2 - Cancelar agendamento");
                    Console.WriteLine("3 - Listar agenda");
                    Console.WriteLine("4 - Voltar p/ menu principal");

                    int op_agenda = int.Parse(Console.ReadLine());

                    switch (op_agenda)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            Console.WriteLine("Voltando para o menu principal");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, voltando para o menu principal");
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Fim do programa");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (op_menu != 3);

    }
}
