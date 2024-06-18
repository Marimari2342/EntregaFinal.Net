using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    public List<Expediente> Ejecutar()
    {
        /*lista todos los expedientes (sin sus trámites) --> */
        return expedienteRepositorio.ObtenerTodos();
    }

}
