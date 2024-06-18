using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repositorio): CasoDeUsoUsuario(repositorio)
{
    public List<Usuario> Ejecutar()
    {
        return Repositorio.GetUsuarios();
    }
}
