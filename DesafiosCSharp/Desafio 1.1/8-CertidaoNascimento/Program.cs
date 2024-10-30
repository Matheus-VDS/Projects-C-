//Autor: Matheus Vieira de Souza

using System;

namespace Classes
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public CertidaoNascimento Certidao { get; private set; }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public void AssociarCertidao(CertidaoNascimento certidao)
        {
            if (Certidao == null)
            {
                Certidao = certidao;
            }
            else
            {
                throw new InvalidOperationException("A certidão de nascimento já está associada a esta pessoa.");
            }
        }
    }

    public class CertidaoNascimento
    {
        public DateTime DataEmissao { get; private set; }
        public Pessoa Pessoa { get; private set; }

        public CertidaoNascimento(DateTime dataEmissao, Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentNullException(nameof(pessoa), "Uma certidão deve estar associada a uma pessoa.");

            DataEmissao = dataEmissao;
            Pessoa = pessoa;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa("João Silva");

            CertidaoNascimento certidao = new CertidaoNascimento(DateTime.Now, pessoa);

            pessoa.AssociarCertidao(certidao);

            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Data de Emissão da Certidão: {certidao.DataEmissao}");
        }
    }
}
