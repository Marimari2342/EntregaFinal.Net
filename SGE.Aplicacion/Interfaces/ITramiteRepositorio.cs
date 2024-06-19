﻿using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
namespace SGE.Aplicacion.Interfaces;

public interface ITramiteRepositorio
{
    void Agregar(Tramite tramite);
    void Eliminar(Tramite tramite);
    void Modificar(Tramite tramite);
    List<Tramite> ListarPorIdExpediente(int id);
    List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta);
    List<Tramite> ListarTramite();
    Tramite ObtenerPorId(int id);

}
