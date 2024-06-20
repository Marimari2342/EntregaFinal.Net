namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

public class CasosDeUsoModificarPermisos(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(int idUsuario, Permiso permiso)
    {
        Repositorio.ModificarPermisos(idUsuario, permiso);  
    }
}