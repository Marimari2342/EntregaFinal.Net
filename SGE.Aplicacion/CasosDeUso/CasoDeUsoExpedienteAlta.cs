using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Exepciones;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio _expedienteRepo, IServicioAutorizacion _servicioAutorizacion )
{       


    public void Ejecutar(Expediente expediente, int IdUsuario){
        if(_servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.ExpedienteAlta)){
            string mensajeError;
            expediente.IdUsuarioUltimaModificacion=IdUsuario;
            if(ExpedienteValidador.Validar(expediente, out mensajeError)){
                expediente.FechaCreacion = DateTime.Now;
                expediente.UltimaModificacion = DateTime.Now;
                expediente.Estado = EstadoExpediente.RecienIniciado;
                expediente.Id = _expedienteRepo.ObtenerSiguienteId();
                // Guardar expediente en el repositorio
                _expedienteRepo.Agregar(expediente);
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

