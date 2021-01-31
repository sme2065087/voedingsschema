﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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


        public ActionResult Index()
        {
            return View(db.MaaltijdUsers.ToList());
        }

        public ActionResult Vandaag()
        {
           
            var maaltijdUsers = db.MaaltijdUsers.Where(u => u.Client.Id == userId).Include(p => p.Gerecht);

            return View(maaltijdUsers.ToList());
        }

        public ActionResult Week()
        {
            return View();
        }

    }
}