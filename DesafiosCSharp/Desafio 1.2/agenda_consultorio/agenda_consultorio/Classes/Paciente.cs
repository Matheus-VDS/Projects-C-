using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_consultorio.Classes
{
    internal class Paciente
    {
        public int CPF { get; set; }
        public string nome { get; set; }
        public DateOnly dataNascimento { get; set; }
        public int idade { get; set; }

        Paciente() { }

        public void cadastrarPaciente(int CPF, string nome, DateOnly dataNascimento) { }
        public void excluirPaciente(int CPF) { }
        public void listarPacientesCPF() { }

    }
}
