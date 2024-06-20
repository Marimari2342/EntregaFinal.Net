
namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public interface IUsuarioRepositorio
{
    List<Usuario> GetUsuarios();
    Usuario? GetUsuario(int id);
    
    void ModificarUsuario(Usuario usuario);
    void EliminarUsuario(Usuario usuario);
    void AgregarUsuario(Usuario usuario);
    void ModificarPermisos(int idUsuario, Permiso permisos);
}
