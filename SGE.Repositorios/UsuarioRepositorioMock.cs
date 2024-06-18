using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
namespace AL.Repositorios;
public class UsuarioRepositorioMock : IUsuarioRepositorio
{
    private readonly List<Usuario> _listaUsuarios = new List<Usuario>(){
        new Usuario(){Id=1,Nombre="Alberto",Apellido="García"},
        new Usuario(){Id=2,Nombre="Ana",Apellido="Perez"}
    };//hemos hardcodeado dos clientes en la lista
    static int s_proximoId = 3;
    private Usuario Clonar(Usuario u) //se van a devolver copias de los cliente guardados
    {
        return new Usuario()
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido
        };
    }
public void AgregarUsuario(Usuario usuario){
    usuario.Id = s_proximoId++;
    _listaUsuarios.Add(Clonar(usuario));
}
public void EliminarUsuario(int id){
    var usuario = _listaUsuarios.SingleOrDefault(u => u.Id == id);
    if (usuario!= null){
        _listaUsuarios.Remove(usuario);
    }
}
public Usuario? GetUsuario(int id){
    Usuario? u = _listaUsuarios.SingleOrDefault(u => u.Id == id);
    if (u != null){
        return Clonar(u);
    }
    return null;
}
public List<Usuario> GetUsuarios(){
    return _listaUsuarios.Select(u => Clonar(u)).ToList();
}
public void ModificarUsuario(Usuario usuario){
    var usu = _listaUsuarios.SingleOrDefault(u => u.Id == usuario.Id);
    if (usu != null){
        usu.Apellido = usuario.Apellido;
        usu.Nombre = usuario.Nombre;
    }
}

}
