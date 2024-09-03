using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.DAL
{
    public class usuariosDAL
    {
        public DataSet LoginUsuario(string nomuser, string pass)
        {
            List<Usuarios> list = new List<Usuarios>();
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("Nombres", typeof(string));
            dt.Columns.Add("Apellidos", typeof(string));

            PetFunnyEntities context = new PetFunnyEntities();

            list = (from user in context.Usuarios where user.UserName == nomuser && user.Password == pass select user).ToList();

            foreach (Usuarios items in list)
            {
                DataRow row = dt.NewRow();
                row["UserName"] = items.UserName;
                row["Password"] = items.Password;
                row["Nombres"] = items.Nombres;
                row["Apellidos"] = items.Apellidos;
                dt.Rows.Add(row);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet ReadAllUsuarios()
        {
            List<Usuarios> list = new List<Usuarios>();
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("Nombres", typeof(string));
            dt.Columns.Add("Apellidos", typeof(string));


            PetFunnyEntities context = new PetFunnyEntities();

            list = (from usuarios in context.Usuarios select usuarios).ToList();


            foreach (Usuarios items in list)
            {
                DataRow row = dt.NewRow();
                row["UserName"] = items.UserName;
                row["Password"] = items.Password;
                row["Nombres"] = items.Nombres;
                row["Apellidos"] = items.Apellidos;

                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(string usernames, string pass, string nombres, string apellidos)
        {
            bool transaction = false;
            try
            {
                PetFunnyEntities context = new PetFunnyEntities();

                Usuarios objprod = new Usuarios();
                objprod.UserName = usernames;
                objprod.Password = pass;
                objprod.Nombres = nombres;
                objprod.Apellidos = apellidos;
                context.Usuarios.Add(objprod);
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
        public bool Editar(string usernames, string pass, string nombres, string apellidos)
        {
            bool transaction = false;
            try
            {
                PetFunnyEntities context = new PetFunnyEntities();

                Usuarios objPro = context.Usuarios.Single(usua => usua.UserName == usernames);
                objPro.Password = pass;
                objPro.Nombres = nombres;
                objPro.Apellidos = apellidos;
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
        public bool Eliminar(string usernames)
        {
            bool transaction = false;
            try
            {
                PetFunnyEntities context = new PetFunnyEntities();

                var deleteOrderDetails =
                from details in context.Usuarios
                where details.UserName == usernames
                select details;

                foreach (var detail in deleteOrderDetails)
                {
                    context.Usuarios.Remove(detail);
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
