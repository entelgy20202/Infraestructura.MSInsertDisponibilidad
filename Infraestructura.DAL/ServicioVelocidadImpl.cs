using Infraestructura.BusinessEntities;
using Infraestructura.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infraestructura.DAL
{
    public class ServicioVelocidadImpl : IServicioVelocidad
    {
        private readonly IConfiguration Configuration;

        public ServicioVelocidadImpl(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> InsertVelocidad(Velocidad velocidad)
        {
            var connectionString = Configuration.GetSection("connectionString").Value;

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var conn = new SqlConnection(connectionString))
            {
                const string sql = "INSERT INTO [dbo].[velocidad]" +
                                   "([velbajada], [velsubida], [fechamed], [codregion], [IdContrato]) " +
                                   " VALUES " +
                                   "(@Velbajada, @Velsubida, @Fechamed, @Codregion, @IdContrato)";

                await using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Velbajada", velocidad.velbajada);
                    cmd.Parameters.AddWithValue("@Velsubida", velocidad.velsubida);
                    cmd.Parameters.AddWithValue("@Fechamed", velocidad.fechamed);
                    cmd.Parameters.AddWithValue("@Codregion", velocidad.codregion);
                    cmd.Parameters.AddWithValue("@IdContrato", velocidad.IdContrato);

                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
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
            return velocidad.Id;
        }
    }
}