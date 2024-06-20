namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
public abstract class CasoDeUsoUsuario
{   
     protected IUsuarioRepositorio Repositorio { get; private set;} 
     public CasoDeUsoUsuario(IUsuarioRepositorio repositorio)
     {
       this.Repositorio = repositorio;
     }
    
}
