using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetFunny.WEB
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            string mensaje = txtMensaje.Text;

           
            Response.Write("<script>alert('¡Gracias por contactarnos! Nos pondremos en contacto contigo pronto.');</script>");
        }
    }
}