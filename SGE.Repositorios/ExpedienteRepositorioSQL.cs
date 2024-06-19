using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ExpedienteRepositorioSQL:IExpedienteRepositorio
{
    public ExpedienteRepositorioSQL(){
        using(var context=new EntidadesContext()){  
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
    //Caso de uso expediente ALTA
    public void Agregar(Expediente e){
        
        using(var db=new EntidadesContext()){  
            db.Add(e);
            db.SaveChanges();
        }
    }

    //Caso de uso expediente BAJA
    public void Eliminar(Expediente e){
        using(var db=new EntidadesContext()){  
            var expediente = db.Expedientes.Where(t => t.Id == e.Id).SingleOrDefault();
            if(expediente != null){
                 db.Remove(expediente);
                 db.SaveChanges();
        }
        }
    }

    //Caso de uso Consulta por Id
    public Expediente ObtenerPorId(int id){
        using(var db=new EntidadesContext()){  
            var expediente = db.Expedientes.Where(t => t.Id == id).SingleOrDefault();
            if (expediente != null) return expediente;
            else{
                var e=new Expediente();
                e.Id=-1;
                return e;  
            } 
        }
    }
    public List<Expediente> ListarExpedientesConSusTramites()
    {
        using(var db = new EntidadesContext()){
            return db.Expedientes.Include(t => t.Tramites).ToList();
        }
    } 
    
    //Caso de uso consulta TODOS
    public List<Expediente> ObtenerTodos(){
        using (var db=new EntidadesContext()){
            List<Expediente> resultado = db.Expedientes.ToList();
            return resultado;  
        }
    }

    //Caso de uso expediente MODIFICACION
    public void Modificar(Expediente e){
        using(var db=new EntidadesContext()){  
            db.Expedientes.Update(e);
            db.SaveChanges();
        }
    }
}