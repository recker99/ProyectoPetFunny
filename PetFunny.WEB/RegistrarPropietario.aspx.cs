using System;
using System.Data;
using System.Web.UI.WebControls;
using PetFunny.BF;

namespace PetFunny.WEB
{
    public partial class RegistrarPropietario : System.Web.UI.Page
    {
        private propietarioBF propietarioBF = new propietarioBF();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPropietarios();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string rut = txtBuscarRut.Text.Trim();
            DataRow propietario = propietarioBF.BuscarPropietarioPorRut(rut);

            if (propietario != null)
            {
                txtRut.Text = propietario["Rut"].ToString();
                txtNombres.Text = propietario["Nombres"].ToString();
                txtApellidos.Text = propietario["Apellidos"].ToString();
                txtTelefono.Text = propietario["Telefono"].ToString();
            }
            else
            {
                lblMensaje.Text = "Propietario no encontrado.";
            }
        }

        protected void btnRegistrarPropietario_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Validación antes de registrar  
            if (string.IsNullOrWhiteSpace(rut) || string.IsNullOrWhiteSpace(nombres) ||
                string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(telefono))
            {
                lblMensaje.Text = "Todos los campos son requeridos.";
                return;
            }

            if (propietarioBF.CrearBF(rut, nombres, apellidos, telefono))
            {
                lblMensaje.Text = "Propietario registrado con éxito.";
                LimpiarFormulario();
                CargarPropietarios();
            }
            else
            {
                lblMensaje.Text = "Error al registrar propietario.";
            }

            // Habilitar el botón de registrar y deshabilitar el de actualizar  
            btnRegistrarPropietario.Enabled = true;
            btnActualizarPropietario.Enabled = false;
        }

        protected void btnActualizarPropietario_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Validación antes de actualizar  
            if (string.IsNullOrWhiteSpace(rut) || string.IsNullOrWhiteSpace(nombres) ||
                string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(telefono))
            {
                lblMensaje.Text = "Todos los campos son requeridos.";
                return;
            }

            if (propietarioBF.EditarBF(rut, nombres, apellidos, telefono))
            {
                lblMensaje.Text = "Propietario actualizado con éxito.";
                LimpiarFormulario();
                CargarPropietarios();
            }
            else
            {
                lblMensaje.Text = "Error al actualizar propietario.";
            }

            // Habilitar el botón de registrar y deshabilitar el de actualizar  
            btnRegistrarPropietario.Enabled = true;
            btnActualizarPropietario.Enabled = false;
        }


        protected void gvPropietarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPropietarios.EditIndex = e.NewEditIndex;
            CargarPropietarios();

            // Deshabilitar el botón de registrar y habilitar el de actualizar  
            btnRegistrarPropietario.Enabled = false;
            btnActualizarPropietario.Enabled = true;
        }

        protected void gvPropietarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string rut = gvPropietarios.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = gvPropietarios.Rows[e.RowIndex];

            string nombres = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string apellidos = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string telefono = ((TextBox)(row.Cells[3].Controls[0])).Text;

            if (propietarioBF.EditarBF(rut, nombres, apellidos, telefono))
            {
                lblMensaje.Text = "Propietario actualizado con éxito.";
            }
            else
            {
                lblMensaje.Text = "Error al actualizar propietario.";
            }

            gvPropietarios.EditIndex = -1;
            CargarPropietarios();
        }

        protected void gvPropietarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rut = gvPropietarios.DataKeys[e.RowIndex].Value.ToString();

            if (propietarioBF.EliminarBF(rut))
            {
                lblMensaje.Text = "Propietario eliminado con éxito.";
            }
            else
            {
                lblMensaje.Text = "Error al eliminar propietario.";
            }

            CargarPropietarios();
        }
        private void CargarPropietarios()
        {
            DataSet ds = propietarioBF.ReadAllBF();
            gvPropietarios.DataSource = ds.Tables[0];
            gvPropietarios.DataBind();
        }

        private void LimpiarFormulario()
        {
            txtRut.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            lblMensaje.Text = ""; // Limpia el mensaje al reiniciar el formulario  
        }
    }
}