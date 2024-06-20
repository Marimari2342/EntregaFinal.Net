using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    List<Usuario> GetUsuarios();
    Usuario? GetUsuario(int id);
    
    void ModificarUsuario(Usuario usuario);
    void EliminarUsuario(Usuario usuario);
    void AgregarUsuario(Usuario usuario);
    void ModificarPermisos(int idUsuario, Permiso permisos);
}
