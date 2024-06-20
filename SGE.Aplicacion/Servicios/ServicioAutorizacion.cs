using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
    public class ServicioAutorizacion : IServicioAutorizacion
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ServicioAutorizacion(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
        {
            // Obtener el usuario desde el repositorio
            Usuario? usuario = _usuarioRepositorio.GetUsuario(IdUsuario);

            if (usuario != null)
            {
                // Verificar si el usuario tiene el permiso requerido
                return usuario.ListaPermisos.Contains(permiso);
            }

            return false; // Si el usuario no existe, no puede tener el permiso
        }
    }
