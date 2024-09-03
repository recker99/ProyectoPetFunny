using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.DAL
{
    public class tipoMascotaDAL
    {
        public DataSet BuscarTiposMascotas(int codigo)
        {
            List<TipoMascota> list = new List<TipoMascota>();
            DataTable dt = new DataTable();
            dt.Columns.Add("idTipoMascota", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));


            PetFunnyEntities context = new PetFunnyEntities();
            list = (from tiposmascotas in context.TipoMascota where tiposmascotas.IdTipoMascota == codigo select tiposmascotas).ToList();

            foreach (TipoMascota items in list)
            {
                DataRow row = dt.NewRow();
                row["idTipoMascota"] = items.IdTipoMascota;
                row["Descripcion"] = items.Descripcion;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        public DataSet ReadAllTipoMascotas()
        {
            List<TipoMascota> list = new List<TipoMascota>();
            DataTable dt = new DataTable();
            dt.Columns.Add("idTipoMascota", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));


            PetFunnyEntities context = new PetFunnyEntities();
            list = (from tiposmascotas in context.TipoMascota select tiposmascotas).ToList();

            foreach (TipoMascota items in list)
            {
                DataRow row = dt.NewRow();
                row["idTipoMascota"] = items.IdTipoMascota;
                row["Descripcion"] = items.Descripcion;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(int idmascota, string Nombre)
        {
            bool transaction = false;
            try
            {
                PetFunnyEntities context = new PetFunnyEntities();
                TipoMascota objprod = new TipoMascota();
                objprod.Descripcion = Nombre;
                context.TipoMascota.Add(objprod);
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }
        public bool Editar(int id, string descripcion)
        {
            bool transaction = false;
            try
            {
                PetFunnyEntities context = new PetFunnyEntities();
                TipoMascota objPro = context.TipoMascota.Single(cato => cato.IdTipoMascota == id);
                objPro.Descripcion = descripcion;
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }
        public bool Eliminar(int id)
        {
            bool transaction = false;
            try
            {
                PetFunnyEntities context = new PetFunnyEntities();
                var deleteOrderDetails =
                from details in context.TipoMascota
                where details.IdTipoMascota == id
                select details;

                foreach (var detail in deleteOrderDetails)
                {
                    context.TipoMascota.Remove(detail);
                }
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }
    }
}
