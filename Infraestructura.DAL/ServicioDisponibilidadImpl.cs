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
                                   "@Finfallo, @Calindicador, @IdContrato); " +
                                   "SELECT SCOPE_IDENTITY();";

                await using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Tipofallo", GetDbNullOrValue(disponibilidad.tipofallo));
                    cmd.Parameters.AddWithValue("@Descfallo", GetDbNullOrValue(disponibilidad.descfallo));
                    cmd.Parameters.AddWithValue("@Respfallo", GetDbNullOrValue(disponibilidad.respfallo));
                    cmd.Parameters.AddWithValue("@Tiempofallo", GetDbNullOrValue(disponibilidad.tiempofallo));
                    cmd.Parameters.AddWithValue("@Iniciofallo", GetDbNullOrValue(disponibilidad.iniciofallo));
                    cmd.Parameters.AddWithValue("@Finfallo", GetDbNullOrValue(disponibilidad.finfallo));
                    cmd.Parameters.AddWithValue("@Calindicador", GetDbNullOrValue(disponibilidad.calindicador));
                    cmd.Parameters.AddWithValue("@IdContrato", GetDbNullOrValue(disponibilidad.IdContrato));

                    try
                    {
                        conn.Open();
                        disponibilidad.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync().ConfigureAwait(false));
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
        private object GetDbNullOrValue(object? obj)
        {
            return obj ?? DBNull.Value;
        }

    }
}