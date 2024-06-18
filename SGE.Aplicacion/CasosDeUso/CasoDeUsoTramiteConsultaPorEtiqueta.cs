using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteConsultaPorEtiqueta (ITramiteRepositorio tramite)
{
   

    public List<Tramite> Ejecutar (EtiquetaTramite etiqueta)
    {
        List<Tramite> t = tramite.ListarPorEtiqueta(etiqueta);
        if (t.Count == 0){
            throw new RepositorioException("No hay trámites con la etiqueta ingresada");
        }
        return t;
    }



}
