using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoUsuario
{   
     protected IUsuarioRepositorio Repositorio { get; private set;} 
     public CasoDeUsoUsuario(IUsuarioRepositorio repositorio)
     {
       this.Repositorio = repositorio;
     }
    
}
