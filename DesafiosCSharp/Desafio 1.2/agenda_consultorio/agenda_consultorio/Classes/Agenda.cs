using System;
using System.Collections.Generic;
using System.Linq;

public class Agenda
{
    private List<Paciente> pacientes = new List<Paciente>();
    private List<Consulta> consultas = new List<Consulta>();

    public void AdicionarPaciente(Paciente paciente)
    {
        if (pacientes.Any(p => p.CPF == paciente.CPF))
            throw new ArgumentException("Erro: CPF já cadastrado.");

        pacientes.Add(paciente);
        Console.WriteLine("Paciente cadastrado com sucesso!");
    }

    public void RemoverPaciente(string cpf)
    {
        var paciente = pacientes.FirstOrDefault(p => p.CPF == cpf);
        if (paciente == null) throw new ArgumentException("Erro: Paciente não cadastrado.");
        if (consultas.Any(c => c.CPF == cpf && c.DataConsulta >= DateTime.Now.Date))
            throw new InvalidOperationException("Erro: Paciente possui consulta futura agendada.");

        consultas.RemoveAll(c => c.CPF == cpf);
        pacientes.Remove(paciente);
        Console.WriteLine("Paciente excluído com sucesso!");
    }

    public void AgendarConsulta(Consulta consulta)
    {
        if (!pacientes.Any(p => p.CPF == consulta.CPF))
            throw new ArgumentException("Erro: Paciente não cadastrado.");

        if (consultas.Any(c => c.DataConsulta == consulta.DataConsulta &&
                               ((consulta.HoraInicial >= c.HoraInicial && consulta.HoraInicial < c.HoraFinal) ||
                                (consulta.HoraFinal > c.HoraInicial && consulta.HoraFinal <= c.HoraFinal))))
            throw new InvalidOperationException("Erro: Já existe uma consulta agendada nesse horário.");

        consultas.Add(consulta);
        Console.WriteLine("Agendamento realizado com sucesso!");
    }

    public void ListarPacientes(bool ordenarPorCPF = true)
    {
        var listaPacientes = ordenarPorCPF ? pacientes.OrderBy(p => p.CPF) : pacientes.OrderBy(p => p.Nome);
        foreach (var paciente in listaPacientes)
        {
            Console.WriteLine($"CPF: {paciente.CPF} | Nome: {paciente.Nome} | Data Nascimento: {paciente.DataNascimento:dd/MM/yyyy} | Idade: {paciente.Idade}");
            var consultaFutura = consultas.FirstOrDefault(c => c.CPF == paciente.CPF && c.DataConsulta >= DateTime.Now.Date);
            if (consultaFutura != null)
            {
                Console.WriteLine($"   Agendado para: {consultaFutura.DataConsulta:dd/MM/yyyy} - {consultaFutura.HoraInicial:hh\\:mm} às {consultaFutura.HoraFinal:hh\\:mm}");
            }
        }
    }

    public void ListarAgenda(DateTime? dataInicial = null, DateTime? dataFinal = null)
    {
        var agendaFiltrada = consultas.Where(c => (!dataInicial.HasValue || c.DataConsulta >= dataInicial.Value) &&
                                                  (!dataFinal.HasValue || c.DataConsulta <= dataFinal.Value))
                                      .OrderBy(c => c.DataConsulta).ThenBy(c => c.HoraInicial);

        foreach (var consulta in agendaFiltrada)
        {
            var paciente = pacientes.FirstOrDefault(p => p.CPF == consulta.CPF);
            if (paciente != null)
            {
                Console.WriteLine($"Data: {consulta.DataConsulta:dd/MM/yyyy} | Início: {consulta.HoraInicial:hh\\:mm} | Fim: {consulta.HoraFinal:hh\\:mm} | Nome: {paciente.Nome} | Nascimento: {paciente.DataNascimento:dd/MM/yyyy}");
            }
        }
    }

    public void CancelarAgendamento(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
    {
        var consulta = consultas.Find(c => c.CPF == cpf && c.DataConsulta == dataConsulta && c.HoraInicial == horaInicial);

        if (consulta == null)
        {
            throw new Exception("Erro: agendamento não encontrado.");
        }

        if (consulta.DataConsulta < DateTime.Today ||
           (consulta.DataConsulta == DateTime.Today && consulta.HoraInicial < DateTime.Now.TimeOfDay))
        {
            throw new Exception("Erro: apenas consultas futuras podem ser canceladas.");
        }

        consultas.Remove(consulta);
        Console.WriteLine("Agendamento cancelado com sucesso!");
    }
}
