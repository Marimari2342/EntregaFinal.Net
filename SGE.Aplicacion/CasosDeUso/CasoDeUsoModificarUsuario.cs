using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasosDeUsoModificarUsuario(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(Usuario usuario)
    {
        Repositorio.ModificarUsuario(usuario);  
    }
}
