namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Excepciones;

public class CasoDeUsoTramiteModificacion (ITramiteRepositorio _tramiteRepositorio, IServicioAutorizacion servicioAutorizacion,ServicioActualizacionEstado actualizar)
{
     public void Ejecutar(Tramite tramite, int idUsuario)
    {
        
            // Verificar permisos
            if(servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion)){
                tramite.IdUsuarioUltimaModificacion = idUsuario;
                // Validar tramite
                string mensajeError;
                if(!TramiteValidador.Validar(tramite,out mensajeError)){
                    throw new ValidacionException(mensajeError);
                }
                else{
                    // Asignar fecha de modificación
                    tramite.UltimaModificacion = DateTime.Now;
                    // Guardar tramite en el repositorio
                    var aux=_tramiteRepositorio.ObtenerPorId(tramite.Id);
                    
                    if (aux != null ){
                        tramite.ExpedienteId=aux.ExpedienteId;
                        tramite.FechaCreacion=aux.FechaCreacion;
                         _tramiteRepositorio.Modificar(tramite);
                        //Actualizar estado del expediente
                        actualizar.ActualizarEstado(aux.ExpedienteId);
                    }
                    else{
                        throw new RepositorioException("El trámite con el id ingresado no existe.");
                    }
                }
            }
             else{
                throw new AutorizacionException();
             }
    }

}
