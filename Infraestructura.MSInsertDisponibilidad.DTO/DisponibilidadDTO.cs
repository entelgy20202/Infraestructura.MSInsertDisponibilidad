using System;

namespace Infraestructura.MSInsertDisponibilidad.DTO
{
    public class DisponibilidadDTO
    {
        public int IdContrato { get; set; }
        public string tipoFallo { get; set; }

        public string descFallo { get; set; }

        public TimeSpan tiempoFallo { get; set; }

        public bool responFallo { get; set; }

        public DateTime inicioFallo { get; set; }
        public DateTime finFallo { get; set; }

        public string codDDA { get; set; }
        public decimal calculoIndicador { get; set; }
    }
}