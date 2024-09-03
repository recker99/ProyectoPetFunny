using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.BF
{
    public class usuariosBF
    {
        public DataSet LoginUsuarioBF(string nomuser, string pass)
        {

            DataSet ds = new DataSet();
            PetFunny.DAL.usuariosDAL capaDatos = new PetFunny.DAL.usuariosDAL();
            ds = capaDatos.LoginUsuario(nomuser, pass);
            return ds;
        }
        public DataSet ReadAllUsuariosBF()
        {
            DataSet ds = new DataSet();
            PetFunny.DAL.usuariosDAL capaDatos = new PetFunny.DAL.usuariosDAL();
            ds = capaDatos.ReadAllUsuarios();
            return ds;
        }

        public bool CrearBF(string usernames, string pass, string nombres, string apellidos)
        {
            bool transaction = false;
            PetFunny.DAL.usuariosDAL capaDatos = new PetFunny.DAL.usuariosDAL();
            transaction = capaDatos.Crear(usernames, pass, nombres, apellidos);
            return transaction;
        }
        public bool EditarBF(string usernames, string pass, string nombres, string apellidos)
        {
            bool transaction = false;
            PetFunny.DAL.usuariosDAL capaDatos = new PetFunny.DAL.usuariosDAL();
            transaction = capaDatos.Editar(usernames, pass, nombres, apellidos);
            return transaction;
        }
        public bool EliminarBF(string usernames)
        {
            bool transaction = false;
            PetFunny.DAL.usuariosDAL capaDatos = new PetFunny.DAL.usuariosDAL();
            transaction = capaDatos.Eliminar(usernames);
            return transaction;
        }
    }
}
