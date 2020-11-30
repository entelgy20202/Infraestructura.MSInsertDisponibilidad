using Infraestructura.BusinessEntities;
using Infraestructura.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infraestructura.DAL
{
    public class ServicioAspectosFinancierosImpl : IServicioAspectosFinancieros
    {
        private readonly IConfiguration Configuration;

        public ServicioAspectosFinancierosImpl(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> InsertarAspectosFinancieros(Aspfinancieros aspecto)
        {
            var connectionString = Configuration.GetSection("connectionString").Value;

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var conn = new SqlConnection(connectionString))
            {
                const string sql = "INSERT INTO [dbo].[aspfinancieros]" +
                                   "([Idcontrato], [valorcontrato], [fechacontrato], [valoradicion]," +
                                   "[fechaadicion], [fechapgaadicion], [valordesembolso], [fechapdesembolso]," +
                                   "[valoranticipo], [fechaanticipo], [valorutilizacion], [numeroactaapro], " +
                                   "[fechautilizacion], [valorrendimiento], [fecharendimiento], [numcomprendimiento], " +
                                   "[valorcomisionfiducia], [fechacomision], [valorgastosadmon], [fechagastosadmon], " +
                                   "[nombrefiducia], [numerocontratofiducia], [fechacontratofiducia], [fechapadicionfiducia]) " +
                                   "VALUES " +
                                   "(@Idcontrato, @Valorcontrato, @Fechacontrato, @Valoradicion, @Fechaadicion, " +
                                   "@Fechapgaadicion, @Valordesembolso, @Fechapdesembolso, @Valoranticipo, @Fechaanticipo, " +
                                   "@Valorutilizacion, @Numeroactaapro, @Fechautilizacion, @Valorrendimiento, " +
                                   ",@Fecharendimiento, @Numcomprendimiento, @Valorcomisionfiducia, @Fechacomision, " +
                                   "@Valorgastosadmon, @Fechagastosadmon, @Nombrefiducia, @Numerocontratofiducia, " +
                                   "@Fechacontratofiducia, @Fechapadicionfiducia)";

                await using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Idcontrato", aspecto.Idcontrato);
                    cmd.Parameters.AddWithValue("@Valorcontrato", aspecto.valorcontrato);
                    cmd.Parameters.AddWithValue("@Fechacontrato", aspecto.fechacontrato);
                    cmd.Parameters.AddWithValue("@Valoradicion", aspecto.valoradicion);
                    cmd.Parameters.AddWithValue("@Fechaadicion", aspecto.fechaadicion);

                    cmd.Parameters.AddWithValue("@Fechapgaadicion", aspecto.fechapgaadicion);
                    cmd.Parameters.AddWithValue("@Valordesembolso", aspecto.valordesembolso);
                    cmd.Parameters.AddWithValue("@Fechapdesembolso", aspecto.fechapdesembolso);
                    cmd.Parameters.AddWithValue("@Valoranticipo", aspecto.valoranticipo);
                    cmd.Parameters.AddWithValue("@Fechaanticipo", aspecto.fechaanticipo);

                    cmd.Parameters.AddWithValue("@Valorutilizacion", aspecto.valorutilizacion);
                    cmd.Parameters.AddWithValue("@Numeroactaapro", aspecto.numeroactaapro);
                    cmd.Parameters.AddWithValue("@Fechautilizacion", aspecto.fechautilizacion);
                    cmd.Parameters.AddWithValue("@Valorrendimiento", aspecto.valorrendimiento);

                    cmd.Parameters.AddWithValue("@Fecharendimiento", aspecto.fecharendimiento);
                    cmd.Parameters.AddWithValue("@Numcomprendimiento", aspecto.numcomprendimiento);
                    cmd.Parameters.AddWithValue("@Valorcomisionfiducia", aspecto.valorcomisionfiducia);
                    cmd.Parameters.AddWithValue("@Fechacomision", aspecto.fechacomision);

                    cmd.Parameters.AddWithValue("@Valorgastosadmon", aspecto.valorgastosadmon);
                    cmd.Parameters.AddWithValue("@Fechagastosadmon", aspecto.fechagastosadmon);
                    cmd.Parameters.AddWithValue("@Nombrefiducia", aspecto.nombrefiducia);
                    cmd.Parameters.AddWithValue("@Numerocontratofiducia", aspecto.numerocontratofiducia);
                    cmd.Parameters.AddWithValue("@Fechacontratofiducia", aspecto.fechacontratofiducia);
                    cmd.Parameters.AddWithValue("@Fechapadicionfiducia", aspecto.fechapadicionfiducia);

                    var param = new SqlParameter("@Id", SqlDbType.Int, 4)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(param);
                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        aspecto.Id = Convert.ToInt32(cmd.Parameters["@Id"].Value);
                    }
                    catch (SqlException sEx)
                    {
                        Console.WriteLine(sEx.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return aspecto.Id;
        }
    }
}