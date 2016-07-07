using System.Web.Mvc;

namespace NBC.Web.Areas.SV
{
    public class SVAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SV_default",
                "SV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}