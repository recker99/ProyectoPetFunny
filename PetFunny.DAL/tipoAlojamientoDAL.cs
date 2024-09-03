using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.DAL
{
    public class tipoAlojamientoDAL
    {
        public DataSet ReadTiposAlojamiento()
        {
            List<TipoAlojamiento> list = new List<TipoAlojamiento>();
            DataTable dt = new DataTable();
            dt.Columns.Add("idTipoAlojamiento", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                list = (from alojamientos in context.TipoAlojamiento
                        select alojamientos).ToList();

                foreach (TipoAlojamiento items in list)
                {
                    DataRow row = dt.NewRow();
                    row["idTipoAlojamiento"] = items.IdTipoAlojamiento;
                    row["Descripcion"] = items.Descripcion;
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
    }
}

