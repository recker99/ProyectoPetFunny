using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetFunny.WEB
{
    public partial class Cerrar_Sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Clear(); 
            Session.Abandon(); 

            // Redirige al usuario a la página de inicio o  login  
            Response.Redirect("Default.aspx");
        }
    }
}