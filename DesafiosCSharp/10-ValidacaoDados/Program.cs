//Autor: Matheus Vieira de Souza
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ValidacaoDados
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome = LerNome();
            string cpf = LerCPF();
            DateTime dataNascimento = LerDataNascimento();
            float rendaMensal = LerRendaMensal();
            char estadoCivil = LerEstadoCivil();
            int dependentes = LerDependentes();

            // Exibindo os dados válidos
            Console.WriteLine("\nDados do Cliente:");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"CPF: {cpf}");
            Console.WriteLine($"Data de Nascimento: {dataNascimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Renda Mensal: R$ {rendaMensal:F2}");
            Console.WriteLine($"Estado Civil: {estadoCivil}");
            Console.WriteLine($"Dependentes: {dependentes}");
        }

        static string LerNome()
        {
            string nome;
            do
            {
                Console.Write("Informe o nome (mínimo 5 caracteres): ");
                nome = Console.ReadLine();
                if (nome.Length < 5)
                    Console.WriteLine("Erro: O nome deve ter pelo menos 5 caracteres.");
            } while (nome.Length < 5);

            return nome;
        }

        static string LerCPF()
        {
            string cpf;
            string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"; 
            do
            {
                Console.Write("Informe o CPF (formato 123.456.789-01): ");
                cpf = Console.ReadLine();
                if (!Regex.IsMatch(cpf, pattern))
                    Console.WriteLine("Erro: CPF inválido. Deve seguir o formato 123.456.789-01.");
            } while (!Regex.IsMatch(cpf, pattern));

            return cpf;
        }

        static DateTime LerDataNascimento()
        {
            DateTime dataNascimento;
            do
            {
                Console.Write("Informe a data de nascimento (DD/MM/AAAA): ");
                string entrada = Console.ReadLine();
                if (!DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
                {
                    Console.WriteLine("Erro: Data inválida. Use o formato DD/MM/AAAA.");
                    continue;
                }

                if (dataNascimento > DateTime.Now.AddYears(-18))
                {
                    Console.WriteLine("Erro: O cliente deve ter pelo menos 18 anos.");
                }
            } while (dataNascimento > DateTime.Now.AddYears(-18));

            return dataNascimento;
        }

        static float LerRendaMensal()
        {
            float rendaMensal;
            do
            {
                Console.Write("Informe a renda mensal (valor ≥ 0, use vírgula para casas decimais): ");
                string entrada = Console.ReadLine();
                if (!float.TryParse(entrada.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out rendaMensal) || rendaMensal < 0)
                {
                    Console.WriteLine("Erro: Renda inválida. Deve ser um valor maior ou igual a zero.");
                }
            } while (rendaMensal < 0);

            return rendaMensal;
        }

        static char LerEstadoCivil()
        {
            char estadoCivil = '\0';
            do
            {
                Console.Write("Informe o estado civil (C, S, V ou D): ");
                string entrada = Console.ReadLine();

                if (entrada.Length != 1 || !"CSVD".Contains(char.ToUpper(entrada[0])))
                {
                    Console.WriteLine("Erro: Estado civil inválido. Use C, S, V ou D.");
                    continue;
                }

                estadoCivil = char.ToUpper(entrada[0]);
            } while (!"CSVD".Contains(estadoCivil));

            return estadoCivil;
        }


        static int LerDependentes()
        {
            int dependentes;
            do
            {
                Console.Write("Informe o número de dependentes (0 a 10): ");
                if (!int.TryParse(Console.ReadLine(), out dependentes) || dependentes < 0 || dependentes > 10)
                {
                    Console.WriteLine("Erro: O número de dependentes deve estar entre 0 e 10.");
                }
            } while (dependentes < 0 || dependentes > 10);

            return dependentes;
        }
    }
}
