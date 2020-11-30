using Infraestructura.BusinessEntities;
using System.Threading.Tasks;

namespace Infraestructura.DAL.Interfaces
{
    public interface IServicioVelocidad
    {
        public Task<int> InsertVelocidad(Velocidad velocidad);
    }
}