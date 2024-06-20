namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Excepciones;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio,IServicioAutorizacion _servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente,int idUsuario)
    { 

            if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion)){
                expediente.IdUsuarioUltimaModificacion=idUsuario;
                string mensajeError;
                if (ExpedienteValidador.Validar(expediente, out mensajeError)){
                    // Asignar fecha de modificación
                    expediente.UltimaModificacion = DateTime.Now;
                    Expediente? aux = expedienteRepositorio.ObtenerPorId(expediente.Id);
                    if(aux!=null){ 
                         expediente.Estado = aux.Estado;
                        expedienteRepositorio.Modificar(expediente);
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
