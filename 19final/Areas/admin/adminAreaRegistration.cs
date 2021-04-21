using System.Web.Mvc;

namespace _19final.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller="adminaccount", action = "Login", id = UrlParameter.Optional },
                new string[] { "_19final.Areas.admin.Controllers" }
            );
        }
    }
}



