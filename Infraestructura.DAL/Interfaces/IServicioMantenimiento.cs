using Infraestructura.BusinessEntities;
using System.Threading.Tasks;

namespace Infraestructura.DAL.Interfaces
{
    public interface IServicioMantenimiento
    {
        public Task<int> InsertMantenimiento(Mantenimiento mantenimiento);
    }
}