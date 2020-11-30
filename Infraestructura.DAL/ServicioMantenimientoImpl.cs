using Infraestructura.BusinessEntities;
using Infraestructura.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infraestructura.DAL
{
    public class ServicioMantenimientoImpl : IServicioMantenimiento
    {
        private readonly IConfiguration Configuration;

        public ServicioMantenimientoImpl(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> InsertMantenimiento(Mantenimiento mantenimiento)
        {
            var connectionString = Configuration.GetSection("connectionString").Value;

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var conn = new SqlConnection(connectionString))
            {
                const string sql = "INSERT INTO [dbo].[mantenimiento]" +
                                   "([numtkt], [codregion], [IdContrato])" +
                                   " VALUES " +
                                   "(@Numtkt, @Codregion, @IdContrato)";

                await using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Numtkt", mantenimiento.numtkt);
                    cmd.Parameters.AddWithValue("@Codregion", mantenimiento.codregion);
                    cmd.Parameters.AddWithValue("@IdContrato", mantenimiento.IdContrato);

                    var param = new SqlParameter("@Id", SqlDbType.Int, 4)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(param);
                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        mantenimiento.Id = Convert.ToInt32(cmd.Parameters["@Id"].Value);
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
            return mantenimiento.Id;
        }
    }
}