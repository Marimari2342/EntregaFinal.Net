using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoAgregarUsuario(IUsuarioRepositorio repositorio): CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar (Usuario usuario){
        //Aquí se puede insertar codigo de vvalidacion  de usuario
        Repositorio.AgregarUsuario(usuario); 
    }
}
/*public class CasoDeUsoAgregarUsuario(IUsuarioRepositorio repositorio, IHashService hashService): CasoDeusoUsuario(repositorio)
{
    private readonly IUsuarioRepositorio _repositorio;
    private readonly IHashService _hashService;

    public void Ejecutar(Usuario usuario)
    {
        // Crear el hash y la sal para la contraseña
        var (hash, salt) = _hashService.CreateHash(usuario.Contraseña);
        usuario.HashContraseña = hash;
        usuario.SalContraseña = salt;
        usuario.Contraseña = ""; // Limpiar la contraseña original

        _repositorio.AgregarUsuario(usuario);
    }
}*/
