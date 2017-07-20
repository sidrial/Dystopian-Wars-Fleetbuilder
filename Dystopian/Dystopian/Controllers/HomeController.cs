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
            //example usage
            var db = new DystopianRepository();
            var coaFleet = db.Squadrons.Where(s => s.FactionID == Faction.COA).ToList();
            var kobFleet = db.Squadrons.Where(s => s.FactionID == Faction.KOB).ToList();
            var allLargeAndMassives = db.Ships.Where(s => s.Size == "L").ToList();

            switch (faction)
            {
                case Enums.Faction.COA:
                    var fleet = new List<Ship>
            {
                new Ship{
                    Id = 1,
                    Name = "Aristotle",
                    BasePoints = 185,
                    CurrentPoints = 185,
                    MinSquadronSize = 1,
                    MaxSquadronSize = 1,
                    Size = "L",
                    Options = new List<Option>()
                    {
                        new Option{
                             Name = "Target Painter Generator",
                            Value = "(Primary Weaponry, 12”)",
                             Points = 5,
                             OptionGroup = 1
                        },
                        new Option {
                             Name = "Disruption Generator",
                               Value = "(8”)",
                             Points = 5,
                             OptionGroup = 1
                        }
                    }
    },
                new Ship {
                    Id = 2,
                    Name = "Zeno",
                    BasePoints = 100,
                    CurrentPoints = 100,
                    MinSquadronSize = 1,
                    MaxSquadronSize = 3,
                    Size = "M",
                    Options = new List<Option>()
                },
                new Ship {
                    Id = 3,
                    Name = "Thales",
                    BasePoints = 20,
                    CurrentPoints = 20,
                    MinSquadronSize = 2,
                    MaxSquadronSize = 5,
                    Size = "S",
                     Options = new List<Option>()
                },
                 new Ship {
                    Id = 4,
                    Name = "Pericles",
                    BasePoints = 170,
                    CurrentPoints = 170,
                    MinSquadronSize = 1,
                    MaxSquadronSize = 1,
                    Size = "L",
                     Options = new List<Option>()
                     {
                         new Option{
                            Name = "Energy Weapons",
                            Value = "",
                             Points = 15,

                         }
                     }
                },
                 new Ship {
                    Id = 4,
                    Name = "Plutarch",
                    BasePoints = 45,
                    CurrentPoints = 45,
                    MinSquadronSize = 2,
                    MaxSquadronSize = 3,
                    Size = "S",
                     Options = new List<Option>()
                }
            };
                    return Json(fleet, JsonRequestBehavior.AllowGet);
                case Enums.Faction.FSA:
                    break;
                case Enums.Faction.RC:
                    break;
                case Enums.Faction.KOB:
                    var kobfleet = new List<Ship>
            {
                new Ship{
                    Id = 1,
                    Name = "Avenger",
                    BasePoints = 200,
                    CurrentPoints = 200,
                    MinSquadronSize = 1,
                    MaxSquadronSize = 1,
                    Size = "L",
                    Options = new List<Option>()
                    {

                    }
    }
            };
                    return Json(kobfleet, JsonRequestBehavior.AllowGet);
                case Enums.Faction.EOTBS:
                    break;
                case Enums.Faction.ROF:
                    break;
                case Enums.Faction.PE:
                    break;
                default:
                    break;
            }

            return Json(new List<Ship>(), JsonRequestBehavior.AllowGet);
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