using Infraestructura.BusinessEntities;
using System.Threading.Tasks;

namespace Infraestructura.DAL.Interfaces
{
    public interface IServicioDisponibilidad
    {
        public Task<int> CrearDisponibilidad(Disponibilidad disponibilidad);
    }
}