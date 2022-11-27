using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Controllers
{
    public class TrackTimeVwController : Controller
    {
        // GET: TrackTimeVw
        public async Task<ActionResult> Index()
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            List<TrackTimeVw> trackTimesVw = new List<TrackTimeVw>();

            trackTimesVw = await trackTimeDAL.GetTrackTimeVw();

            //TODO - retornar TrackTimeVw

            return View(trackTimesVw);
        }
    }
}