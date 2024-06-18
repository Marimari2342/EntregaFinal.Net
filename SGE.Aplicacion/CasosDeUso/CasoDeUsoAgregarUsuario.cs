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
