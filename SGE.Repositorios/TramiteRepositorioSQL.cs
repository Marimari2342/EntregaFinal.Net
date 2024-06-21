namespace SGE.Repositorios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Enumerativos;
public class TramiteRepositorioSQL: ITramiteRepositorio
{
    static TramiteRepositorioSQL(){
        using(var context = new EntidadesContext()){
            context.Database.EnsureCreated();
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }

    public void Agregar(Tramite tramite){
        using (var db = new EntidadesContext()){
            db.tramites.Add(tramite);
            db.SaveChanges();
        }
    }

    public void Eliminar (Tramite tramite){
        using(var db = new EntidadesContext()){
            db.tramites.Remove(tramite);
            db.SaveChanges();
        }
    }

   public void Modificar(Tramite tramite){
        using(var db = new EntidadesContext()){
            db.tramites.Update(tramite);
            db.SaveChanges();
        }
    } 

  public List <Tramite> ListarPorIdExpediente(int id){
        using (var db=new EntidadesContext()){
            var resultado = db.tramites.Where(t => t.ExpedienteId == id).ToList();
            return resultado; 
        }
    }
   
  public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta){
    using (var db = new EntidadesContext()){
        var resultado = db.tramites.Where(t => t.Etiqueta == etiqueta).ToList();
        return resultado;
    }
  }

  public List<Tramite> ListarTramite(){
    using (var db = new EntidadesContext()){
        return db.tramites.ToList();
    }
  }

  public Tramite? ObtenerPorId(int id)
  {
    using (var db = new EntidadesContext())
    {
        return db.tramites.FirstOrDefault(t => t.Id == id);
    }
   }
}


