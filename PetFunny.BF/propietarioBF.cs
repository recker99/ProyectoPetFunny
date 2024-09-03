using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.BF
{
    public class propietarioBF
    {
        public DataSet ReadAllBF()
        {

            DataSet ds = new DataSet();
            PetFunny.DAL.propietarioDAL capaDatos = new PetFunny.DAL.propietarioDAL();
            ds = capaDatos.ReadAllPropietarios();

            return ds;
        }

        public bool CrearBF(string rut, string nombres, string apellidos, string telefonos)
        {
            bool transaction = false;
            PetFunny.DAL.propietarioDAL capaDatos = new PetFunny.DAL.propietarioDAL();
            transaction = capaDatos.Crear(rut, nombres, apellidos, telefonos);

            return transaction;
        }
        public bool EditarBF(string rut, string nombres, string apellidos, string telefonos)
        {
            bool transaction = false;
            PetFunny.DAL.propietarioDAL capaDatos = new PetFunny.DAL.propietarioDAL();
            transaction = capaDatos.Editar(rut, nombres, apellidos, telefonos);
            return transaction;
        }
        public bool EliminarBF(string rut)
        {
            bool transaction = false;
            PetFunny.DAL.propietarioDAL capaDatos = new PetFunny.DAL.propietarioDAL();
            transaction = capaDatos.Eliminar(rut);
            return transaction;
        }

        public DataRow BuscarPropietarioPorRut(string rut)
        {
            PetFunny.DAL.propietarioDAL capaDatos = new PetFunny.DAL.propietarioDAL();
            DataSet ds = capaDatos.ReadAllPropietarios();

            DataRow[] propietario = ds.Tables[0].Select($"Rut = '{rut}'");

            if (propietario.Length > 0)
            {
                return propietario[0];
            }
            else
            {
                return null;
            }
        }
    }
}
