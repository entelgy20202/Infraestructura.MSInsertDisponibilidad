using Infraestructura.BusinessEntities;
using Infraestructura.DAL.Interfaces;
using Infraestructura.MSInsertDisponibilidad.Domain.Interfaces;
using Infraestructura.MSInsertDisponibilidad.DTO;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace Infraestructura.MSInsertDisponibilidad.Domain
{
    public class InsertarDisponibilidadImpl : IInsertarDisponibilidad
    {
        public IServicioDisponibilidad _disponibilidadService;

        public InsertarDisponibilidadImpl(IServicioDisponibilidad disponibilidad)
        {
            _disponibilidadService = disponibilidad;
        }

        public async Task<int> ExecuteAsync(DisponibilidadDTO inobj)
        {
            Disponibilidad objTo = DisponiDTOTodisponibilidadDAL(inobj);
            objTo.IdContrato = inobj.IdContrato;
            int interno = await _disponibilidadService.CrearDisponibilidad(objTo);
            return interno;
        }

        private Disponibilidad DisponiDTOTodisponibilidadDAL(DisponibilidadDTO inobj)
        {
            Disponibilidad objTo = new Disponibilidad();

            objTo.calindicador = inobj.calculoIndicador;
            objTo.descfallo = inobj.descFallo;

            //objTo.codsercapac = inobj.codSerCapacitacion;
            objTo.finfallo = inobj.finFallo;
            objTo.iniciofallo = inobj.inicioFallo;
            objTo.respfallo = inobj.responFallo;

            objTo.tiempofallo = inobj.tiempoFallo;

            objTo.tipofallo = inobj.tipoFallo;

            objTo.iniciofallo = null;
            if (inobj.inicioFallo != null && inobj.inicioFallo > SqlDateTime.MinValue.Value) objTo.iniciofallo = inobj.inicioFallo;

            objTo.finfallo = null;
            if (inobj.finFallo != null && inobj.finFallo > SqlDateTime.MinValue.Value) objTo.iniciofallo = inobj.finFallo;

            return objTo;
        }
    }
}