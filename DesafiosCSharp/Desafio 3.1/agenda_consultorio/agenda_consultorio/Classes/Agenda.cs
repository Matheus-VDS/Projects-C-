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
        Console.WriteLine("Paciente exclu�do com sucesso!");
    }

    public void AgendarConsulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal)
    {
        // Verifica se o CPF existe no cadastro
        var paciente = pacientes.Find(p => p.CPF == cpf);
        if (paciente == null)
        {
            throw new Exception("Erro: paciente n�o cadastrado.");
        }

        // Valida a data da consulta no formato DDMMAAAA
        if (dataConsulta < DateTime.Today ||
            (dataConsulta == DateTime.Today && horaInicial <= DateTime.Now.TimeOfDay))
        {
            throw new Exception("Erro: o agendamento deve ser para um hor�rio futuro.");
        }

        // Verifica se hora final � maior que hora inicial
        if (horaFinal <= horaInicial)
        {
            throw new Exception("Erro: hora final deve ser maior que a hora inicial.");
        }

        // Verifica se o paciente j� tem um agendamento futuro
        var agendamentoExistente = consultas.Find(c => c.CPF == cpf && c.DataConsulta > DateTime.Today);
        if (agendamentoExistente != null)
        {
            throw new Exception("Erro: o paciente j� tem um agendamento futuro.");
        }

        // Verifica se o agendamento n�o est� sobrepondo outro
        foreach (var consulta in consultas)
        {
            if (consulta.DataConsulta == dataConsulta &&
                ((horaInicial >= consulta.HoraInicial && horaInicial < consulta.HoraFinal) ||
                 (horaFinal > consulta.HoraInicial && horaFinal <= consulta.HoraFinal)))
            {
                throw new Exception("Erro: o hor�rio est� sobrepondo outro agendamento.");
            }
        }

        // Verifica se a hora inicial e final s�o v�lidas (de 15 em 15 minutos)
        if (horaInicial.Minutes % 15 != 0 || horaFinal.Minutes % 15 != 0)
        {
            throw new Exception("Erro: a hora deve ser m�ltiplo de 15 minutos.");
        }

        // Verifica se o hor�rio de agendamento est� dentro do hor�rio de funcionamento
        if (horaInicial < new TimeSpan(8, 0, 0) || horaFinal > new TimeSpan(19, 0, 0))
        {
            throw new Exception("Erro: o hor�rio de agendamento deve estar entre 08:00 e 19:00.");
        }

        // Agendamento v�lido, cria uma nova consulta
        var novaConsulta = new Consulta(cpf, dataConsulta, horaInicial, horaFinal);
        consultas.Add(novaConsulta);
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
                Console.WriteLine($"   Agendado para: {consultaFutura.DataConsulta:dd/MM/yyyy} - {consultaFutura.HoraInicial:hh\\:mm} �s {consultaFutura.HoraFinal:hh\\:mm}");
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
                Console.WriteLine($"Data: {consulta.DataConsulta:dd/MM/yyyy} | In�cio: {consulta.HoraInicial:hh\\:mm} | Fim: {consulta.HoraFinal:hh\\:mm} | Nome: {paciente.Nome} | Nascimento: {paciente.DataNascimento:dd/MM/yyyy}");
            }
        }
    }

    public void CancelarAgendamento(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
    {
        var consulta = consultas.Find(c => c.CPF == cpf && c.DataConsulta == dataConsulta && c.HoraInicial == horaInicial);

        if (consulta == null)
        {
            throw new Exception("Erro: agendamento n�o encontrado.");
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
