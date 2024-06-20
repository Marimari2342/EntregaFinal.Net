namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoObtenerUsuario(IUsuarioRepositorio repositorio): CasoDeUsoUsuario(repositorio)
{
    public Usuario? Ejecutar(int id){
        return Repositorio.GetUsuario(id);
    }
}
