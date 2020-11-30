using Infraestructura.MSInsertDisponibilidad.DTO;
using System.Threading.Tasks;

namespace Infraestructura.MSInsertDisponibilidad.Domain.Interfaces
{
    public interface IInsertarDisponibilidad
    {
        Task<int> ExecuteAsync(DisponibilidadDTO inobj);
    }
}