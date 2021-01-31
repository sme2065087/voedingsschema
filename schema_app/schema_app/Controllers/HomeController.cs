
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using schema_app.Models;
using Microsoft.AspNet.Identity;

namespace schema_app.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize]
        public ActionResult Index()
        {
            return Redirect("/Home/Vandaag");
        }

        [Authorize]
        public ActionResult Vandaag()
        {
           
            var maaltijdUsers = db.MaaltijdUsers.Where(u => u.Client.Id == userId).Include(p => p.Gerecht);

            return View(maaltijdUsers.ToList());
        }

        [Authorize]
        public ActionResult Week()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckBoxUpdate(string ID, string Checked)
        {

            var dbCommand = "UPDATE MaaltijdUsers SET voldaan='True' WHERE Id='" + ID + "'";
            System.Diagnostics.Debug.WriteLine("My debug string here");
            if (Checked == "false" || Checked == "False")
            {
                dbCommand = "UPDATE MaaltijdUsers SET voldaan='False' WHERE Id='" + ID + "'";
            }

            db.Database.ExecuteSqlCommand(dbCommand);

            return Redirect("/Home/Vandaag");
        }

    }
}