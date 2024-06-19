using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoEliminarUsuario(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(Usuario usuario)
    {
        Repositorio.EliminarUsuario(usuario);
    }
}
