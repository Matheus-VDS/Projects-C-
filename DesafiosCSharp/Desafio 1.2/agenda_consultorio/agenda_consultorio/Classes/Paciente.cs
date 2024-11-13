using System;

public class Paciente
{
    public string CPF { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;

    public Paciente(string cpf, string nome, DateTime dataNascimento)
    {
        if (!ValidarCPF(cpf)) throw new ArgumentException("Erro: CPF inválido.");
        if (nome.Length < 5) throw new ArgumentException("Erro: Nome deve ter pelo menos 5 caracteres.");
        if (Idade < 13) throw new ArgumentException("Erro: Paciente deve ter pelo menos 13 anos.");

        CPF = cpf;
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    private bool ValidarCPF(string cpf)
    {
        // Lógica de validação de CPF
        return true; // Retorne true para CPF válido, e false caso contrário
    }
}
