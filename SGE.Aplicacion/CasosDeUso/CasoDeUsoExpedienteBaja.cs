﻿using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteBaja(IServicioAutorizacion servicioAutorizacion,IExpedienteRepositorio expedienteRepositorio)
{
     public void Ejecutar(int idExpediente, int idUsuario)
    {    
           // Verificar permisos
           if(servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja)){
               // Eliminar expediente en el repositorio
                var expediente = expedienteRepositorio.ObtenerPorId(idUsuario);
                if(expediente != null){
                    expedienteRepositorio.Eliminar(expediente);
                }
                else{
                 throw new RepositorioException("El expediente que quiere dar de baja no existe ");
               }      
           }
           else{
               throw new AutorizacionException();
           }
    }
}
