using System;
using System.Data;
using PetFunny.DAL;

namespace PetFunny.BF
{
    public class alojamientoBF
    {
        // Método para buscar alojamientos por RUT  
        public DataSet BuscarAlojamientosBF(string rut)
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.BuscarAlojamientos(rut);
        }

        public DataSet ObtenerAlojamientoPorRut(string rut)
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.ObtenerAlojamientoPorRut(rut);
        }

        // Método para leer todos los tipos de mascotas  
        public DataSet ReadAllTipoMascotasBF()
        {
            tipoMascotaDAL capaDatos = new tipoMascotaDAL();
            DataSet ds = capaDatos.ReadAllTipoMascotas();

            if (ds.Tables.Count > 0 && ds.Tables[0].Columns.Contains("Descripcion"))
            {
                return ds;
            }
            else
            {
                throw new Exception("La columna 'Descripcion' no existe en el DataSet devuelto.");
            }
        }

        // Método para leer tipos de mascota  
        public DataSet ReadTipoMascota()
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.ReadTiposMascota();
        }

        // Método para crear un nuevo registro de alojamiento  
        public bool CrearBF(string rut, string nombreMascota, int idTipoMascota, int idTipoAlojamiento, DateTime fecha, int dias)
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.Crear(rut, nombreMascota, idTipoMascota, idTipoAlojamiento, fecha, dias);
        }

        // Método para leer todos los alojamientos  
        public DataSet ReadAllBF()
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.ReadAlojamientos();
        }

        // Método para editar un registro de alojamiento  
        public bool EditarBF(string rut, string nombreMascota, int idTipoMascota, int idTipoAlojamiento, DateTime fecha, int dias)
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.Editar(rut, nombreMascota, idTipoMascota, idTipoAlojamiento, fecha, dias);
        }

        // Método para eliminar un registro de alojamiento  
        public bool EliminarBF(string rut)
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.EliminarBF(rut);
        }

        // Método para obtener todos los tipos de mascotas  
        public DataSet ObtenerTiposMascota()
        {
            return ReadAllTipoMascotasBF();
        }

        // Método para obtener todos los tipos de alojamiento  
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

        // Método para obtener alojamientos que están por finalizar  
        public DataSet FinalizacionAlojamientos(DateTime fechaConsulta)
        {
            AlojamientoDAL capaDatos = new AlojamientoDAL();
            return capaDatos.FinalizacionAlojamientos(fechaConsulta);
        }
    }
}