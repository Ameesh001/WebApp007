using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication007.Models;

namespace WebApplication007
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AddRoles();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddRoles()
        {
            try
            {
                using (DBEntities3 objDB = new DBEntities3())
                {
                    if (!objDB.Roles.Any(x => x.RoleName == "Admin"))
                    {
                        Role mRole = new Role
                        {
                            RoleName = "Admin",
                            IsActive = true
                        };
                        objDB.Roles.Add(mRole);
                        objDB.SaveChanges();
                    }

                }
            }
            catch (System.Exception)
            {


            }
        }
    }
}
