namespace Infraestructura.BusinessEntities
{
    public class Aspfinancieros
    {
        public int Id { get; set; }
        public int? Idcontrato { get; set; }
        public decimal? valorcontrato { get; set; }
        public System.DateTime? fechacontrato { get; set; }
        public decimal? valoradicion { get; set; }
        public System.DateTime? fechaadicion { get; set; }
        public System.DateTime? fechapgaadicion { get; set; }
        public decimal? valordesembolso { get; set; }
        public System.DateTime? fechapdesembolso { get; set; }
        public decimal? valoranticipo { get; set; }
        public System.DateTime? fechaanticipo { get; set; }
        public decimal? valorutilizacion { get; set; }
        public string numeroactaapro { get; set; }
        public System.DateTime? fechautilizacion { get; set; }
        public decimal? valorrendimiento { get; set; }
        public System.DateTime? fecharendimiento { get; set; }
        public string numcomprendimiento { get; set; }
        public decimal? valorcomisionfiducia { get; set; }
        public System.DateTime? fechacomision { get; set; }
        public decimal? valorgastosadmon { get; set; }
        public System.DateTime? fechagastosadmon { get; set; }
        public string nombrefiducia { get; set; }
        public string numerocontratofiducia { get; set; }
        public System.DateTime? fechacontratofiducia { get; set; }
        public System.DateTime? fechapadicionfiducia { get; set; }
    }
}