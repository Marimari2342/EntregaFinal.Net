namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Excepciones;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio _tramiteRepositorio, IServicioAutorizacion _servicioAutorizacion,ServicioActualizacionEstado actualizar)
{
        public void Ejecutar(Tramite tramite, int idUsuario){
                // Verificar permisos
                if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja)){
                    tramite.IdUsuarioUltimaModificacion = idUsuario;
                    Tramite? aux = _tramiteRepositorio.ObtenerPorId(tramite.Id);
                    if(aux != null){
                        _tramiteRepositorio.Eliminar(tramite);
                        actualizar.ActualizarEstado(aux.ExpedienteId);
                    }
                    else{
                        throw new RepositorioException("Id de trámite no encontrado");
                    }
                }
                else{
                    throw new AutorizacionException();
                } 
        }

}
