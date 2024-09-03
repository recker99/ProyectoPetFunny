using System;
using System.Data;
using System.Web.UI.WebControls;
using PetFunny.BF;

namespace PetFunny.WEB
{
    public partial class RegistrarAlojamientos : System.Web.UI.Page
    {
        private alojamientoBF alojamientoBF = new alojamientoBF();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                CargarTiposDeMascota();
                CargarTiposDeAlojamiento();
                CargarAlojamientos();
            }
        }

        protected void btnBuscarPorRut_Click(object sender, EventArgs e)
        {
            string rut = txtRutBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(rut))
            {
                lblMensaje.Text = "El campo Rut es requerido para la búsqueda.";
                return;
            }

            try
            {
                DataSet ds = alojamientoBF.ObtenerAlojamientoPorRut(rut);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvAlojamientos.DataSource = ds;
                    gvAlojamientos.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No se encontraron alojamientos para el Rut especificado.";
                    gvAlojamientos.DataSource = null;
                    gvAlojamientos.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
            }
        }

        protected void btnRegistrarAlojamiento_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string nombreMascota = txtNombreMascota.Text.Trim();
            int idTipoMascota = int.Parse(ddlIdTipoMascota.SelectedValue);
            int idTipoAlojamiento = int.Parse(ddlIdTipoAlojamiento.SelectedValue);
            DateTime fechaIngreso;
            int dias;

            // Validación de campos
            if (string.IsNullOrWhiteSpace(rut))
            {
                lblMensaje.Text = "El campo Rut es requerido.";
                return;
            }
            if (string.IsNullOrWhiteSpace(nombreMascota))
            {
                lblMensaje.Text = "El campo Nombre de Mascota es requerido.";
                return;
            }
            if (idTipoMascota <= 0)
            {
                lblMensaje.Text = "Selecciona un tipo de mascota válido.";
                return;
            }
            if (idTipoAlojamiento <= 0)
            {
                lblMensaje.Text = "Selecciona un tipo de alojamiento válido.";
                return;
            }
            if (!DateTime.TryParse(txtFechaIngreso.Text.Trim(), out fechaIngreso))
            {
                lblMensaje.Text = "Formato de fecha incorrecto.";
                return;
            }
            if (!int.TryParse(txtDias.Text.Trim(), out dias) || dias <= 0)
            {
                lblMensaje.Text = "El campo Días debe ser un número positivo.";
                return;
            }

            // Intentar registrar el alojamiento
            try
            {
                if (alojamientoBF.CrearBF(rut, nombreMascota, idTipoMascota, idTipoAlojamiento, fechaIngreso, dias))
                {
                    lblMensaje.Text = "Alojamiento registrado con éxito.";
                    LimpiarFormulario();
                    CargarAlojamientos();
                }
                else
                {
                    lblMensaje.Text = "Error al registrar alojamiento.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
            }
        }

        private void CargarAlojamientos()
        {
            DataSet ds = alojamientoBF.ReadAllBF();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAlojamientos.DataSource = ds.Tables[0];
                gvAlojamientos.DataBind();
            }
            else
            {
                lblMensaje.Text = "No se encontraron alojamientos.";
                gvAlojamientos.DataSource = null;
                gvAlojamientos.DataBind();
            }
        }

        private void LimpiarFormulario()
        {
            txtRut.Text = "";
            txtNombreMascota.Text = "";
            ddlIdTipoMascota.ClearSelection();
            ddlIdTipoAlojamiento.ClearSelection();
            txtFechaIngreso.Text = "";
            txtDias.Text = "";
            lblMensaje.Text = "";
        }

        private void CargarTiposDeMascota()
        {
            DataSet ds = alojamientoBF.ObtenerTiposMascota(); // Método que obtiene la lista de tipos de mascota

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine("Id: " + row["IdTipoMascota"] + ", Descripcion: " + row["Descripcion"]);
                }

                ddlIdTipoMascota.DataSource = ds;
                ddlIdTipoMascota.DataTextField = "Descripcion";
                ddlIdTipoMascota.DataValueField = "IdTipoMascota";
                ddlIdTipoMascota.DataBind();
                ddlIdTipoMascota.Items.Insert(0, new ListItem("Seleccione", ""));
            }
        }

        private void CargarTiposDeAlojamiento()
        {
            DataSet ds = alojamientoBF.ObtenerTiposAlojamiento(); // Método que obtiene la lista de tipos de alojamientos

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine("Id: " + row["IdTipoAlojamiento"] + ", Descripcion: " + row["Descripcion"]);
                }

                ddlIdTipoAlojamiento.DataSource = ds;  
                ddlIdTipoAlojamiento.DataTextField = "Descripcion";
                ddlIdTipoAlojamiento.DataValueField = "IdTipoAlojamiento";
                ddlIdTipoAlojamiento.DataBind();
                ddlIdTipoAlojamiento.Items.Insert(0, new ListItem("Seleccione", ""));
            }
        }

        protected void gvAlojamientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string rut = gvAlojamientos.DataKeys[index].Value.ToString();
                EliminarAlojamiento(rut);
            }
        }

        private void EliminarAlojamiento(string rut)
        {
            try
            {
                if (alojamientoBF.EliminarBF(rut))
                {
                    lblMensaje.Text = "Alojamiento eliminado con éxito.";
                    CargarAlojamientos();
                }
                else
                {
                    lblMensaje.Text = "Error al eliminar el alojamiento.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
            }
        }

    }
}
