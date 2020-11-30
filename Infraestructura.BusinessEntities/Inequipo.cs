namespace Infraestructura.BusinessEntities
{
    public class Inequipo
    {
        public int Id { get; set; }
        public string codinstal { get; set; }
        public System.DateTime? fechaini { get; set; }
        public System.DateTime? fechafin { get; set; }
        public string descequipo { get; set; }
        public int? IdMantenimiento { get; set; }
        public virtual Mantenimiento mantenimiento { get; set; }
    }
}