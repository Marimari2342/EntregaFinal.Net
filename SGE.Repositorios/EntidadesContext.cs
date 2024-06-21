namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

public class EntidadesContext: DbContext 
{
    #nullable disable
    public DbSet<Usuario> Usuarios { get; set;}
    public DbSet<Expediente> Expedientes { get; set;}
    public DbSet<Tramite> tramites { get; set;}
#nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Entidades.sqlite");

    }

}