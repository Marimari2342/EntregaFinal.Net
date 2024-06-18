using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoObtenerUsuario(IUsuarioRepositorio repositorio): CasoDeUsoUsuario(repositorio)
{
    public Usuario? Ejecutar(int id){
        return Repositorio.GetUsuario(id);
    }
}
