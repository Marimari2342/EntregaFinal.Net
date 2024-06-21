namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoAgregarUsuario(IUsuarioRepositorio repositorio ):CasoDeUsoUsuario(repositorio)
{

    public void Ejecutar(Usuario usuario)
    {
        Repositorio.AgregarUsuario(usuario);
    }
}
