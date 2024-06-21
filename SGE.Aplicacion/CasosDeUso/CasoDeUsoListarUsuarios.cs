namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repositorio): CasoDeUsoUsuario(repositorio)
{
    public List<Usuario> Ejecutar()
    {
        return Repositorio.GetUsuarios();
    }
}
