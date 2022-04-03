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
                using (DBEntities objDB = new DBEntities())
                {
                    if (!objDB.Roles.Any(x => x.RoleName == "Admin"))
                    {
                        Role mRole = new Role();
                        mRole.RoleName = "Admin";
                        mRole.IsActive = true;
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
