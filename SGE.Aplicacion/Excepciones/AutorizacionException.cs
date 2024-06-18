namespace SGE.Aplicacion.Exepciones;

public  class AutorizacionException: Exception
{
   public AutorizacionException(): base("El usuario no tiene los permisos necesarios"){}

}
