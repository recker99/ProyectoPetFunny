using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using PetFunny.WEB.Services; // referencia al servicio WCF  

namespace PetFunny.WEB
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsername.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            var client = new UsuarioService();
            var user = client.ValidarUsuario(nombreUsuario, contrasena);

            if (user != null && user.EsValido) 
            {
                Session["FullName"] = user.Nombre + " " + user.Apellido; 
                Response.Redirect("Default.aspx"); 
            }
            else
            {
                lblMensaje.Text = "Credenciales inválidas.";
            }
        }
    }
}