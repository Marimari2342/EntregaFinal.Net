namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoObtenerListaUsuarios(IUsuarioRepositorio repositorio ):CasoDeUsoUsuario(repositorio)
{

    public List<Usuario> Ejecutar()
    {
       return Repositorio.GetUsuarios();
    }
}

