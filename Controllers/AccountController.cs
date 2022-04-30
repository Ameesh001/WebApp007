using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication007.Models;

namespace WebApplication007.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBEntities3 db = new DBEntities3();

        // GET: Account
        public ActionResult Index()
        {
            
            //var result = db.SP_RolePermission("7", "3").ToList();

            return View(db.Roles.ToList());

        }

        public ActionResult Create([Bind(Include = "RoleName")] Role roldedata)
        {
            if (!string.IsNullOrEmpty(roldedata.RoleName)) {             
                if (!db.Roles.Any(x => x.RoleName == roldedata.RoleName))
                {
                    roldedata.IsActive = true;
                    roldedata.RoleName = char.ToUpper(roldedata.RoleName[0]) + roldedata.RoleName.Substring(1);
                    db.Roles.Add(roldedata);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            Role tblRoles = db.Roles.Find(id);
            db.Roles.Remove(tblRoles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                Role tblRole = db.Roles.Find(id);
                if (tblRole == null)
                {
                    return HttpNotFound();
                }
                return View(tblRole);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //TempData["EditName"] = db.Roles.Where(x => x.RoleID == id).FirstOrDefault().RoleName;
            //TempData["EditName"] = db.Roles.Where(x => x.RoleID == id).FirstOrDefault().RoleName;
            //return View("Index");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "RoleID,RoleName,IsActive")] Role roldedata)
         {
            if (ModelState.IsValid)
            {
                db.Entry(roldedata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roldedata);
        }

        public void Status(int id)
        {
            Role tblRoles = db.Roles.Find(id);
            if (tblRoles.IsActive == true)
            {
                tblRoles.IsActive = false;
            }
            else
            {
                tblRoles.IsActive = true;
            }
            db.Entry(tblRoles).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}