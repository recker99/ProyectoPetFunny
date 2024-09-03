using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PetFunny.DAL
{
    public class propietarioDAL
    {
        public DataSet ReadAllPropietarios()
        {
            List<Propietario> list = new List<Propietario>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Rut", typeof(string));
            dt.Columns.Add("Nombres", typeof(string));
            dt.Columns.Add("Apellidos", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));

            using (PetFunnyEntities context = new PetFunnyEntities())
            {
                list = (from propietarios in context.Propietario select propietarios).ToList();
            }

            foreach (Propietario items in list)
            {
                DataRow row = dt.NewRow();
                row["Rut"] = items.Rut;
                row["Nombres"] = items.Nombres;
                row["Apellidos"] = items.Apellidos;
                row["Telefono"] = items.Telefono;

                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(string rut, string nombres, string apellidos, string telefonos)
        {
            bool transaction = false;
            try
            {
                using (PetFunnyEntities context = new PetFunnyEntities())
                {
                    Propietario nuevoPropietario = new Propietario
                    {
                        Rut = rut,
                        Nombres = nombres,
                        Apellidos = apellidos,
                        Telefono = telefonos
                    };

                    context.Propietario.Add(nuevoPropietario);
                    context.SaveChanges();  
                    transaction = true;  
                }
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);  
            }
            return transaction;
        }

        public bool Editar(string rut, string nombres, string apellidos, string telefonos)
        {
            bool transaction = false;
            try
            {
                using (PetFunnyEntities context = new PetFunnyEntities())
                {
                    var objPro = context.Propietario.SingleOrDefault(p => p.Rut == rut);
                    if (objPro != null)
                    {
                        objPro.Nombres = nombres;
                        objPro.Apellidos = apellidos;
                        objPro.Telefono = telefonos;
                        context.SaveChanges();  
                        transaction = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }

        public bool Eliminar(string rut)
        {
            bool transaction = false;
            try
            {
                using (PetFunnyEntities context = new PetFunnyEntities())
                {
                    var propietario = context.Propietario.SingleOrDefault(p => p.Rut == rut);
                    if (propietario != null)
                    {
                        context.Propietario.Remove(propietario);
                        context.SaveChanges();  
                        transaction = true; 
                    }
                }
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