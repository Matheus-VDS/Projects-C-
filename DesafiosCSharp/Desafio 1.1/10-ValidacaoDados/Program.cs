//Autor: Matheus Vieira de Souza
using System;
using System.Globalization;

namespace ValidacaoDados
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public float RendaMensal { get; private set; }
        public char EstadoCivil { get; private set; }
        public int Dependentes { get; private set; }

        public void LerDados()
        {
            Nome = LerNome();
            CPF = LerCPF();
            DataNascimento = LerDataNascimento();
            RendaMensal = LerRendaMensal();
            EstadoCivil = LerEstadoCivil();
            Dependentes = LerDependentes();
        }

        private string LerNome()
        {
            while (true)
            {
                Console.Write("Nome (mínimo 5 caracteres): ");
                string nome = Console.ReadLine();
                if (nome.Length >= 5)
                    return nome;
                Console.WriteLine("Erro: o nome deve ter pelo menos 5 caracteres.");
            }
        }

        private string LerCPF()
        {
            while (true)
            {
                Console.Write("CPF (apenas dígitos): ");
                string cpf = Console.ReadLine();
                if (ValidarCPF(cpf))
                    return cpf;
                Console.WriteLine("Erro: CPF inválido.");
            }
        }

        private DateTime LerDataNascimento()
        {
            while (true)
            {
                Console.Write("Data de Nascimento (DD/MM/AAAA): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime dataNascimento))
                {
                    int idade = DateTime.Now.Year - dataNascimento.Year;
                    if (dataNascimento > DateTime.Now.AddYears(-idade)) idade--;
                    if (idade >= 18)
                        return dataNascimento;
                    else
                        Console.WriteLine("Erro: o cliente deve ter pelo menos 18 anos.");
                }
                else
                {
                    Console.WriteLine("Erro: formato de data inválido.");
                }
            }
        }

        private float LerRendaMensal()
        {
            while (true)
            {
                Console.Write("Renda Mensal (Ex: 1234,56): ");
                if (float.TryParse(Console.ReadLine().Replace('.', ','), out float renda) && renda >= 0)
                    return renda;
                Console.WriteLine("Erro: renda mensal inválida. Digite um valor ≥ 0.");
            }
        }

        private char LerEstadoCivil()
        {
            while (true)
            {
                Console.Write("Estado Civil (C, S, V, D): ");
                char estadoCivil = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if ("CSVDB".Contains(estadoCivil))
                    return estadoCivil;
                Console.WriteLine("Erro: estado civil inválido.");
            }
        }

        private int LerDependentes()
        {
            while (true)
            {
                Console.Write("Dependentes (0 a 10): ");
                if (int.TryParse(Console.ReadLine(), out int dependentes) && dependentes >= 0 && dependentes <= 10)
                    return dependentes;
                Console.WriteLine("Erro: número de dependentes inválido.");
            }
        }

        private bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf) return false;

            int[] peso1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] peso2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma1 = 0, soma2 = 0;

            for (int i = 0; i < 9; i++)
            {
                soma1 += (cpf[i] - '0') * peso1[i];
                soma2 += (cpf[i] - '0') * peso2[i];
            }

            int digito1 = soma1 % 11 < 2 ? 0 : 11 - (soma1 % 11);
            soma2 += digito1 * peso2[9];
            int digito2 = soma2 % 11 < 2 ? 0 : 11 - (soma2 % 11);

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }

        public void ExibirDados()
        {
            Console.WriteLine("\nDados do Cliente:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Data de Nascimento: {DataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Renda Mensal: {RendaMensal:C}");
            Console.WriteLine($"Estado Civil: {EstadoCivil}");
            Console.WriteLine($"Dependentes: {Dependentes}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.LerDados();
            cliente.ExibirDados();
        }
    }
}

