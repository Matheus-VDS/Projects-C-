using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
        public class Intervalo
        {
            public DateTime DataHoraInicial { get; }
            public DateTime DataHoraFinal { get; }

            public Intervalo(DateTime dataHoraInicial, DateTime dataHoraFinal)
            {
                if (dataHoraInicial > dataHoraFinal)
                    throw new ArgumentException("A data/hora inicial não pode ser maior que a data/hora final.");

                DataHoraInicial = dataHoraInicial;
                DataHoraFinal = dataHoraFinal;
            }

            public bool TemIntersecao(Intervalo outroIntervalo)
            {
                return DataHoraInicial < outroIntervalo.DataHoraFinal && DataHoraFinal > outroIntervalo.DataHoraInicial;
            }

            public bool EhIgual(Intervalo outroIntervalo)
            {
                return DataHoraInicial == outroIntervalo.DataHoraInicial && DataHoraFinal == outroIntervalo.DataHoraFinal;
            }

            public TimeSpan Duracao => DataHoraFinal - DataHoraInicial;
        }
    
}
