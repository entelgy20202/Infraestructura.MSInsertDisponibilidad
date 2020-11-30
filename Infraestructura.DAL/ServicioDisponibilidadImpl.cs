using Infraestructura.BusinessEntities;
using Infraestructura.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infraestructura.DAL
{
    public class ServicioDisponibilidadImpl : IServicioDisponibilidad
    {
        private readonly IConfiguration Configuration;

        public ServicioDisponibilidadImpl(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> CrearDisponibilidad(Disponibilidad disponibilidad)
        {
            var connectionString = Configuration.GetSection("connectionString").Value;

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var conn = new SqlConnection(connectionString))
            {
                const string sql = "INSERT INTO [dbo].[disponibilidad] " +
                                   "([tipofallo], [descfallo], [respfallo], [tiempofallo], [iniciofallo], " +
                                   "[finfallo], [calindicador], [IdContrato]) " +
                                   "VALUES " +
                                   "(@Tipofallo, @Descfallo, @Respfallo, @Tiempofallo, @Iniciofallo, " +
                                   "@Finfallo, @Calindicador, @IdContrato)";

                await using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Tipofallo", disponibilidad.tipofallo);
                    cmd.Parameters.AddWithValue("@Descfallo", disponibilidad.descfallo);
                    cmd.Parameters.AddWithValue("@Respfallo", disponibilidad.respfallo);
                    cmd.Parameters.AddWithValue("@Tiempofallo", disponibilidad.tiempofallo);
                    cmd.Parameters.AddWithValue("@Iniciofallo", disponibilidad.iniciofallo);
                    cmd.Parameters.AddWithValue("@Finfallo", disponibilidad.finfallo);
                    cmd.Parameters.AddWithValue("@Calindicador", disponibilidad.calindicador);
                    cmd.Parameters.AddWithValue("@IdContrato", disponibilidad.IdContrato);

                    var param = new SqlParameter("@Id", SqlDbType.Int, 4)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(param);
                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        disponibilidad.Id = Convert.ToInt32(cmd.Parameters["@Id"].Value);
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
            return disponibilidad.Id;
        }
    }
}