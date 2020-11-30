using Infraestructura.BusinessEntities;
using System.Threading.Tasks;

namespace Infraestructura.DAL.Interfaces
{
    public interface IServicioAspectosFinancieros
    {
        Task<int> InsertarAspectosFinancieros(Aspfinancieros aspecto);
    }
}