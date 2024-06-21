namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    public List<Expediente> Ejecutar()
    {
        /*lista todos los expedientes (sin sus trámites) --> */
        return expedienteRepositorio.ObtenerTodos();
    }

}
