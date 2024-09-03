using System;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Data.Objects.SqlClient;

namespace PetFunny.DAL
{
    public class AlojamientoDAL
    {
        public DataSet BuscarAlojamientos(string rut)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Rut", typeof(string));
            dt.Columns.Add("NombreMascota", typeof(string));
            dt.Columns.Add("IdTipoMascota", typeof(int));
            dt.Columns.Add("IdTipoAlojamiento", typeof(int));
            dt.Columns.Add("FechaIngreso", typeof(DateTime));
            dt.Columns.Add("Dias", typeof(int));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                var list = context.Alojamiento.Where(a => a.Rut == rut).ToList();

                foreach (var item in list)
                {
                    DataRow row = dt.NewRow();
                    row["Rut"] = item.Rut;
                    row["NombreMascota"] = item.NombreMascota;
                    row["IdTipoMascota"] = item.IdTipoMascota;
                    row["IdTipoAlojamiento"] = item.IdTipoAlojamiento;
                    row["FechaIngreso"] = item.FechaIngreso;
                    row["Dias"] = item.Dias;
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet ReadAlojamientos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Rut", typeof(string));
            dt.Columns.Add("NombreMascota", typeof(string));
            dt.Columns.Add("DescripcionMascota", typeof(string));
            dt.Columns.Add("DescripcionAlojamiento", typeof(string));
            dt.Columns.Add("FechaIngreso", typeof(DateTime));
            dt.Columns.Add("Dias", typeof(int));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                var list = from a in context.Alojamiento
                           join tm in context.TipoMascota on a.IdTipoMascota equals tm.IdTipoMascota
                           join ta in context.TipoAlojamiento on a.IdTipoAlojamiento equals ta.IdTipoAlojamiento
                           select new
                           {
                               a.Rut,
                               a.NombreMascota,
                               DescripcionMascota = tm.Descripcion,
                               DescripcionAlojamiento = ta.Descripcion,
                               a.FechaIngreso,
                               a.Dias
                           };

                foreach (var item in list.ToList())
                {
                    DataRow row = dt.NewRow();
                    row["Rut"] = item.Rut;
                    row["NombreMascota"] = item.NombreMascota;
                    row["DescripcionMascota"] = item.DescripcionMascota;
                    row["DescripcionAlojamiento"] = item.DescripcionAlojamiento;
                    row["FechaIngreso"] = item.FechaIngreso;
                    row["Dias"] = item.Dias;
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(string rut, string nombreMascota, int idTipoMascota, int idTipoAlojamiento, DateTime fechaIngreso, int dias)
        {
            try
            {
                using (PetFunnyEntities context = new PetFunnyEntities())
                {
                    var nuevoAlojamiento = new Alojamiento
                    {
                        Rut = rut,
                        NombreMascota = nombreMascota,
                        IdTipoMascota = idTipoMascota,
                        IdTipoAlojamiento = idTipoAlojamiento,
                        FechaIngreso = fechaIngreso,
                        Dias = dias
                    };
                    context.Alojamiento.Add(nuevoAlojamiento);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Editar(string rut, string nombreMascota, int idTipoMascota, int idTipoAlojamiento, DateTime fechaIngreso, int dias)
        {
            try
            {
                using (PetFunnyEntities context = new PetFunnyEntities())
                {
                    var alojamiento = context.Alojamiento.SingleOrDefault(a => a.Rut == rut && a.NombreMascota == nombreMascota);

                    if (alojamiento != null)
                    {
                        alojamiento.IdTipoMascota = idTipoMascota;
                        alojamiento.IdTipoAlojamiento = idTipoAlojamiento;
                        alojamiento.FechaIngreso = fechaIngreso;
                        alojamiento.Dias = dias;

                        context.SaveChanges();
                        return true;
                    }
                    return false; // No se encontró el alojamiento  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool EliminarBF(string rut)
        {
            try
            {
                using (PetFunnyEntities context = new PetFunnyEntities())
                {
                    var alojamiento = context.Alojamiento
                        .SingleOrDefault(a => a.Rut == rut);

                    if (alojamiento != null)
                    {
                        context.Alojamiento.Remove(alojamiento);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public DataSet ReadTiposAlojamiento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdTipoAlojamiento", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
               
                var tiposAlojamiento = context.TipoAlojamiento.ToList();

                foreach (var tipo in tiposAlojamiento)
                {
                    DataRow row = dt.NewRow();
                    row["IdTipoAlojamiento"] = tipo.IdTipoAlojamiento;
                    row["Descripcion"] = tipo.Descripcion; 
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet ReadTiposMascota()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdTipoMascota", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                
                var tiposMascota = context.TipoMascota.ToList();

                foreach (var tipo in tiposMascota)
                {
                    DataRow row = dt.NewRow();
                    row["IdTipoMascota"] = tipo.IdTipoMascota;  
                    row["Descripcion"] = tipo.Descripcion; 
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet ObtenerAlojamientoPorRut(string rut)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Rut", typeof(string));
            dt.Columns.Add("NombreMascota", typeof(string));
            dt.Columns.Add("IdTipoMascota", typeof(int));
            dt.Columns.Add("IdTipoAlojamiento", typeof(int));
            dt.Columns.Add("FechaIngreso", typeof(DateTime));
            dt.Columns.Add("Dias", typeof(int));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                var alojamiento = context.Alojamiento.SingleOrDefault(a => a.Rut == rut);

                if (alojamiento != null)
                {
                    DataRow row = dt.NewRow();
                    row["Rut"] = alojamiento.Rut;
                    row["NombreMascota"] = alojamiento.NombreMascota;
                    row["IdTipoMascota"] = alojamiento.IdTipoMascota;
                    row["IdTipoAlojamiento"] = alojamiento.IdTipoAlojamiento;
                    row["FechaIngreso"] = alojamiento.FechaIngreso;
                    row["Dias"] = alojamiento.Dias;
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet FinalizacionAlojamientos(DateTime fechaConsulta)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NombrePropietario", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("NombreMascota", typeof(string));
            dt.Columns.Add("TipoMascota", typeof(string));
            dt.Columns.Add("TipoAlojamiento", typeof(string));
            dt.Columns.Add("FechaIngreso", typeof(DateTime));
            dt.Columns.Add("FechaTermino", typeof(DateTime));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                //  consultar en la base de datos  
                var list = from a in context.Alojamiento
                           join p in context.Propietario on a.Rut equals p.Rut
                           join tm in context.TipoMascota on a.IdTipoMascota equals tm.IdTipoMascota
                           join ta in context.TipoAlojamiento on a.IdTipoAlojamiento equals ta.IdTipoAlojamiento
                           select new
                           {
                               NombrePropietario = p.Nombres + " " + p.Apellidos,
                               p.Telefono,
                               a.NombreMascota,
                               TipoMascota = tm.Descripcion,
                               TipoAlojamiento = ta.Descripcion,
                               a.FechaIngreso,
                               Dias = a.Dias // Guardamos el número de días  
                           };

                // Convertimos la lista a una lista en memoria  
                var alojamientos = list.ToList();

                // Filtramos en memoria  
                var filteredList = alojamientos.Where(item =>
                    item.FechaIngreso.AddDays(item.Dias).Date >= fechaConsulta.Date).ToList();

                foreach (var item in filteredList)
                {
                    DataRow row = dt.NewRow();
                    row["NombrePropietario"] = item.NombrePropietario;
                    row["Telefono"] = item.Telefono;
                    row["NombreMascota"] = item.NombreMascota;
                    row["TipoMascota"] = item.TipoMascota;
                    row["TipoAlojamiento"] = item.TipoAlojamiento;
                    row["FechaIngreso"] = item.FechaIngreso;
                    row["FechaTermino"] = item.FechaIngreso.AddDays(item.Dias); // Cálculo de FechaTermino  
                    dt.Rows.Add(row);
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
    }
}