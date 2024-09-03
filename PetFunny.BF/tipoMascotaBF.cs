using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.BF
{
    public class tipoMascotaBF
    {
        public DataSet BuscarTiposMascotasBF(int codigo)
        {

            DataSet ds = new DataSet();
            PetFunny.DAL.tipoMascotaDAL capaDatos = new PetFunny.DAL.tipoMascotaDAL();
            ds = capaDatos.BuscarTiposMascotas(codigo);
            return ds;
        }


        public DataSet ReadAllTipoMascotasBF()
        {

            DataSet ds = new DataSet();
            PetFunny.DAL.tipoMascotaDAL capaDatos = new PetFunny.DAL.tipoMascotaDAL();

            ds = capaDatos.ReadAllTipoMascotas();
            return ds;
        }

        public bool CrearBF(int idmascota, string Nombre)
        {
            bool transaction = false;
            PetFunny.DAL.tipoMascotaDAL capaDatos = new PetFunny.DAL.tipoMascotaDAL();
            return transaction;
        }
        public bool EditarBF(int id, string descripcion)
        {
            bool transaction = false;
            PetFunny.DAL.tipoMascotaDAL capaDatos = new PetFunny.DAL.tipoMascotaDAL();
            transaction = capaDatos.Crear(id, descripcion);
            return transaction;
        }
        public bool EliminarBF(int id)
        {
            bool transaction = false;
            PetFunny.DAL.tipoMascotaDAL capaDatos = new PetFunny.DAL.tipoMascotaDAL();
            transaction = capaDatos.Eliminar(id);
            return transaction;
        }
    }
}
