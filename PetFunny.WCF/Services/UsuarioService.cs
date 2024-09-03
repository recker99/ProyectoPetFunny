using PetFunny.DAL;
using System.Linq;

namespace PetFunny.WEB.Services
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioDTO ValidarUsuario(string nombreUsuario, string contrasena)
        {
            using (var context = new PetFunnyEntities())
            {
                var usuario = context.Usuarios
                    .FirstOrDefault(u => u.UserName == nombreUsuario && u.Password == contrasena);

                if (usuario != null)
                {
                    return new UsuarioDTO
                    {
                        Nombre = usuario.Nombres,
                        Apellido = usuario.Apellidos,
                        EsValido = true
                    };
                }

                return new UsuarioDTO { EsValido = false };
            }
        }
    }
}
