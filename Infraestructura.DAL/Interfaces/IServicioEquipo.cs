using Infraestructura.BusinessEntities;
using System.Threading.Tasks;

namespace Infraestructura.DAL.Interfaces
{
    public interface IServicioEquipo
    {
        public Task<int> CrearEquipo(Inequipo inEquipo);
    }
}