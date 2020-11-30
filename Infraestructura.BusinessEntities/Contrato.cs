namespace Infraestructura.BusinessEntities
{
    public class Contrato
    {
        public int Id { get; set; }
        public string numero { get; set; }
        public int? ano { get; set; }
        public string daneBeneficiario { get; set; }
        public string idBeneficiario { get; set; }
        public string nombreBeneficiario { get; set; }
        public System.DateTime fecha { get; set; }
        public string dirbnf { get; set; }
    }
}