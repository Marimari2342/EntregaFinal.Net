using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    List<Usuario> GetUsuarios();
    Usuario? GetUsuario(int id);
    
    void ModificarUsuario(Usuario usuario);
    void EliminarUsuario(int id);
    void AgregarUsuario(Usuario usuario);
}
