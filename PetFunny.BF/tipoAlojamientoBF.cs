using PetFunny.DAL;
using System;
using System.Data;

namespace PetFunny.BF
{
    public class tipoAlojamientoBF
    {
        public DataSet ObtenerTiposAlojamiento()
        {
            tipoAlojamientoDAL capaDatos = new tipoAlojamientoDAL();
            DataSet ds = capaDatos.ReadTiposAlojamiento();

            if (ds.Tables.Count > 0 && ds.Tables[0].Columns.Contains("Descripcion"))
            {
                return ds;
            }
            else
            {
                throw new Exception("La columna 'Descripcion' no existe en el DataSet devuelto.");
            }
        }
    }
}
