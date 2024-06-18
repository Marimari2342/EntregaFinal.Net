using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoUsuario(IUsuarioRepositorio repositorio)
{   
     protected IUsuarioRepositorio Repositorio { get; } = repositorio;
    
}
