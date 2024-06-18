using SGE.Aplicacion.Enumerativos;
namespace SGE.Aplicacion.Interfaces;

public interface IEspecificacionCambioEstado
{
  EstadoExpediente ObtenerNuevoEstado(EtiquetaTramite etiquetaTramite, EstadoExpediente estadoActual);
}
