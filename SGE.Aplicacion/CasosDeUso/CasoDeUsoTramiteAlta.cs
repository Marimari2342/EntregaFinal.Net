using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Excepciones;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio,IServicioAutorizacion _servicioAutorizacion,ServicioActualizacionEstado actualizar)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
            // Verificar permisos
            if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta)){
                tramite.IdUsuarioUltimaModificacion=idUsuario;
                string mensajeError;
                // Validar tramite
                if(TramiteValidador.Validar(tramite, out mensajeError)){ 
                    // Asignar Id 
                    tramite.Id = tramiteRepositorio.ObtenerSiguienteId(); 
                    // Asignar fecha de creación y modificación
                    tramite.FechaCreacion = DateTime.Now;
                    tramite.UltimaModificacion = DateTime.Now;
                    // Guardar tramite en el repositorio
                    tramiteRepositorio.Agregar(tramite);
                    //Actualizar estado del expediente
                    actualizar.ActualizarEstado(tramite.ExpedienteId);

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
