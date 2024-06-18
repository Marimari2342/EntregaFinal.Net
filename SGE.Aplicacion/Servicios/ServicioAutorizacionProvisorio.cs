using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.Servicios;

public class ServicioAutorizacionProvisorio: IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso){
        return (IdUsuario==1);
    } 

}
