

using SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set;}
    public string Nombre { get; set;}="";

    public string Apellido{ get; set;}="";
    public string CorreoElectronico { get; set;}="";
    public string Contraseña { get; set;}="";
    public List<Permiso> ListaPermisos{ get; set;} = new List<Permiso>();
}