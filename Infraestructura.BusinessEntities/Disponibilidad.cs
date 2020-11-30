using System;

namespace Infraestructura.BusinessEntities
{
    public class Disponibilidad
    {
        public int Id { get; set; }
        public string tipofallo { get; set; }
        public string descfallo { get; set; }
        public Nullable<bool> respfallo { get; set; }
        public Nullable<System.TimeSpan> tiempofallo { get; set; }
        public Nullable<System.DateTime> iniciofallo { get; set; }
        public Nullable<System.DateTime> finfallo { get; set; }
        public Nullable<decimal> calindicador { get; set; }
        public Nullable<int> IdContrato { get; set; }
    }
}