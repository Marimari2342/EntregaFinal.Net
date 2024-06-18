using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Excepciones;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio,IServicioAutorizacion _servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente,int idUsuario)
    { 
        //hyyyyyyyyyy
            if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion)){
                expediente.IdUsuarioUltimaModificacion=idUsuario;
                string mensajeError;
                if (ExpedienteValidador.Validar(expediente, out mensajeError)){
                // Asignar fecha de modificación
                expediente.UltimaModificacion = DateTime.Now;
                Expediente aux = expedienteRepositorio.ObtenerPorId(expediente.Id);
                expediente.Estado = aux.Estado;
                bool ok;
                expedienteRepositorio.Modificar(expediente,out ok);  
                if(!ok){
                    throw new RepositorioException("El expediente con el id ingresado no existe");
                }
                }   
                 else{
                throw new ValidacionException(mensajeError);
                }
            }
            else{
                throw new AutorizacionException();
            }
    }
}
