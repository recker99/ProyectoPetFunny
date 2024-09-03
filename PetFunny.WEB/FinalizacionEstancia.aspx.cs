using System;
using System.Data; 
using System.Web.UI.WebControls;
using PetFunny.BF; //  

namespace PetFunny.WEB
{
    public partial class FinalizacionEstancia : System.Web.UI.Page
    {
        private alojamientoBF alojamientoBF = new alojamientoBF();
        private int pageIndex = 1;
        private int pageSize = 15;  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAlojamientos(DateTime.Now); // Cargar alojamientos con la fecha actual  
            }
        }

        private void CargarAlojamientos(DateTime fechaConsulta)
        {
            try
            {
                // Llamar al método FinalizacionAlojamientos   
                DataSet data = alojamientoBF.FinalizacionAlojamientos(fechaConsulta);

                // Asumiendo que la tabla de datos está en la primera tabla del DataSet  
                if (data.Tables.Count > 0)
                {
                    gvAlojamientos.DataSource = data.Tables[0];
                    gvAlojamientos.DataBind();
                }

                // Deshabilitar el botón "Anterior" si estamos en la primera página  
                btnAnterior.Enabled = pageIndex > 1;
                // Deshabilitar el botón "Siguiente" si no hay más datos  
                btnSiguiente.Enabled = data.Tables.Count > 0 && data.Tables[0].Rows.Count == pageSize;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al cargar los datos: " + ex.Message;
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                CargarAlojamientos(DateTime.Now); // Volver a cargar con la fecha actual  
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            pageIndex++;
            CargarAlojamientos(DateTime.Now); // Volver a cargar con la fecha actual  
        }
    }
}