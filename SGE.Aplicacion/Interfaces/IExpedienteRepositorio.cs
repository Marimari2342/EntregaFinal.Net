using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IExpedienteRepositorio
{
    void Agregar(Expediente expediente);
    void Eliminar(Expediente expediente);
    void Modificar(Expediente expediente);
    Expediente ObtenerPorId(int id);
    List <Expediente> ObtenerTodos();


}
