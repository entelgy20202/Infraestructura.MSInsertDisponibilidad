using System;

namespace Infraestructura.BusinessEntities
{
    public class Velocidad
    {
        public int Id { get; set; }
        public Nullable<decimal> velbajada { get; set; }
        public Nullable<decimal> velsubida { get; set; }
        public Nullable<System.DateTime> fechamed { get; set; }
        public string codregion { get; set; }
        public Nullable<int> IdContrato { get; set; }
        public virtual Contrato contrato { get; set; }
    }
}