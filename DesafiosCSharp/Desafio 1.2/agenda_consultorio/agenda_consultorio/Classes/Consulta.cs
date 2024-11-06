using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_consultorio.Classes
{
    internal class Consulta
    {
        public DateOnly dataConsulta { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }

        Consulta() { }

       public void agendarConsulta(int CPF, DateOnly dataConsulta, DateTime horaInicial, DateTime horaFinal) { }
       public void cancelarConsulta(int CPF, DateOnly dataConsulta, DateTime horaInicial, DateTime horaFinal) { }
       public void listarAgenda() { }
    }
}
