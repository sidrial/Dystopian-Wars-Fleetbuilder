using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Entities;
using Microsoft.SqlServer.Server;
using Option = Dystopian.Models.Option;
using Ship = Dystopian.Models.Ship;

namespace Dystopian.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFactionModels(Enums.Faction faction)
        {
            using (var repository = new DystopianRepository())
            {
                try
                {
                    var factionName = faction.GetDescription();
                    var fleet = repository.Squadrons.Where(s => s.FactionID.Name == factionName).ToList();
                    return Json(fleet, JsonRequestBehavior.AllowGet);
                }
                catch (NullReferenceException)
                {
                    return Json(new List<Squadron>(), JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}