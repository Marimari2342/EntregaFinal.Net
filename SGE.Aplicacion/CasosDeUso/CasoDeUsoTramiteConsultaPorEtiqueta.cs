namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;
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
