using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetFunny.WEB
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] != null) // Verifica si la sesión está activa  
            {
                // Usuario autenticado  
                alojamientosMenu.Visible = true; // Mostrar menú de alojamientos  
                propietariosMenu.Visible = true; // Mostrar menú de propietarios  
                //loginMenu.Visible = false; // Ocultar menú de inicio de sesión  
                //lblWelcome.Text = "Bienvenido, " + Session["FullName"].ToString();  
                //logoutMenu.Visible = true; // Mostrar menú de cerrar sesión   

                string fullName = Session["FullName"].ToString();
                Label lblWelcome = new Label
                {
                    Text = $"Bienvenido, {fullName}",
                    CssClass = "navbar-text me-2" // Añadir clases para estilo  
                };

                Button btnLogout = new Button
                {
                    Text = "Cerrar Sesión",
                    CssClass = "btn btn-danger",
                    ID = "btnLogout"
                };
                btnLogout.Click += BtnLogout_Click; // Suscribir al evento Click  

                // Agregar los controles a userInfo  
                userInfo.Controls.Add(lblWelcome);
                userInfo.Controls.Add(btnLogout);
            }
            else
            {
                // Usuario no autenticado  
                alojamientosMenu.Visible = false; // Ocultar menú de alojamientos  
                propietariosMenu.Visible = false; // Ocultar menú de propietarios  
                //loginMenu.Visible = true; // Mostrar menú de inicio de sesión  
                //logoutMenu.Visible = false; // Ocultar menú de cerrar sesión   

                // Aquí puedes agregar enlaces para Iniciar Sesión y Registrar si es necesario  
                LinkButton btnLogin = new LinkButton
                {
                    Text = "Iniciar Sesión",
                    CssClass = "nav-link",
                    PostBackUrl = "~/Login.aspx"
                };

                userInfo.Controls.Add(btnLogin);

                // Descomentar si deseas agregar un botón de registro  
                /*  
                LinkButton btnRegister = new LinkButton  
                {  
                    Text = "Registrar",  
                    CssClass = "nav-link",  
                    PostBackUrl = "~/Register.aspx"  
                };  

                userInfo.Controls.Add(btnRegister);  
                */
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            // Aquí puedes colocar la lógica para cerrar la sesión  
            Session.Abandon(); // Cerrar la sesión  
            Response.Redirect("~/Default.aspx"); // Redirigir a la página principal después de cerrar sesión  
        }
    }
}