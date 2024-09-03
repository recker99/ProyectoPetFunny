using System;
using System.Web.UI;

namespace PetFunny.WEB
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["FullName"] != null)
                {
                    // Usuario autenticado  
                    lblWelcome.Text = "Bienvenido, " + Session["FullName"].ToString();
                   
                }
                else
                {
                    // Usuario no autenticado  
                    lblWelcome.Text = "Por favor, inicie sesión.";
                   
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Clear(); 
            Session.Abandon();

            // Redirige al usuario a la página de inicio de sesión  
            Response.Redirect("Login.aspx");
        }
    }
}