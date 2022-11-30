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
                        
            return View(trackTimesVw);
        }

        public async Task<ActionResult> Edit(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            TrackTimeVw trackTimeVw;

            trackTimeVw = await trackTimeDAL.GetTrackTimeVw(id);

            return View(trackTimeVw);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                
                TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
                TrackTime trackTime = new TrackTime();
                                
                trackTime.Id = Convert.ToInt32(collection["IdCar"]);
                trackTime.IdTrack = Convert.ToInt32(collection["IdTrack"]);
                trackTime.IdCar = Convert.ToInt32(collection["IdCar"]);
                trackTime.BestTimeLap = TimeSpan.Parse(collection["BestTimeLap"].ToString());
                trackTime.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackTimeDAL.SetTrackTime(trackTime);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            TrackTimeVw trackTimeVw = new TrackTimeVw();

            trackTimeVw = await trackTimeDAL.GetTrackTimeVw(id);

            return View(trackTimeVw);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}