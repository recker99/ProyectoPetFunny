using System;
using System.Web;
using System.Web.UI;

namespace PetFunny.WEB
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Registrar el script de jQuery para la validación unobtrusive  
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.6.0.min.js", // Asegúrate de que la ruta sea correcta  
                DebugPath = "~/Scripts/jquery-3.6.0.min.js", // Cambiar a la ruta de depuración si es necesario  
                CdnPath = "https://code.jquery.com/jquery-3.6.0.min.js" // CDN  
                // Eliminamos 'CdnPathFallback' y 'Version' ya que no son necesarios  
            });
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}