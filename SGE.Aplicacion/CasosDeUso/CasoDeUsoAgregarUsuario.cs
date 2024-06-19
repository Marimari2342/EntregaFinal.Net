using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoAgregarUsuario(IUsuarioRepositorio repositorio, IHashService servicio ):CasoDeUsoUsuario(repositorio)
{

    public void Ejecutar(Usuario usuario)
    {
        // Crear el hash y la sal para la contraseña
        var (hash, salt) = servicio.CreateHash(usuario.Contraseña);
        usuario.HashContraseña = hash;
        usuario.SalContraseña = salt;
        usuario.Contraseña = ""; // Limpiar la contraseña original

        Repositorio.AgregarUsuario(usuario);
    }
}
