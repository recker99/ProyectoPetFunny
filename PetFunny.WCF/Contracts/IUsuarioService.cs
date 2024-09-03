using System.ServiceModel;

namespace PetFunny.WEB.Services
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        UsuarioDTO ValidarUsuario(string nombreUsuario, string contrasena);
    }

    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool EsValido { get; set; }
    }
}
