using Infraestructura.BusinessEntities;
using Infraestructura.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infraestructura.DAL
{
    public class ServicioEquipoImpl : IServicioEquipo
    {
        private readonly IConfiguration Configuration;

        public ServicioEquipoImpl(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> CrearEquipo(Inequipo inEquipo)
        {
            var connectionString = Configuration.GetSection("connectionString").Value;

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var conn = new SqlConnection(connectionString))
            {
                const string sql = "INSERT INTO [dbo].[inequipo]" +
                                   "([codinstal], [fechaini], [fechafin], [descequipo], [IdMantenimiento])" +
                                   " VALUES " +
                                   "(@Codinstal, @Fechaini, @Fechafin, @Descequipo, @IdMantenimiento)";

                await using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Codinstal", inEquipo.codinstal);
                    cmd.Parameters.AddWithValue("@Fechaini", inEquipo.fechaini);
                    cmd.Parameters.AddWithValue("@Fechafin", inEquipo.fechafin);
                    cmd.Parameters.AddWithValue("@Descequipo", inEquipo.descequipo);
                    cmd.Parameters.AddWithValue("@IdMantenimiento", inEquipo.IdMantenimiento);

                    var param = new SqlParameter("@Id", SqlDbType.Int, 4)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(param);
                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        inEquipo.Id = Convert.ToInt32(cmd.Parameters["@Id"].Value);
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
            return inEquipo.Id;
        }
    }
}