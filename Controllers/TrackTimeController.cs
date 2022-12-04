using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.Negocio;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Controllers
{
    public class TrackTimeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TrackTimeNG trackTimeNG = new TrackTimeNG();
            List<TrackTime> trackTimes = new List<TrackTime>();

            trackTimes = await trackTimeNG.GetTrackTimes();
                        
            return View(trackTimes);
        }

        public async Task<ActionResult> Create()
        {
            TrackTimeNG trackTimeNG = new TrackTimeNG();
            TrackTime trackTime = await trackTimeNG.GetTrackTimeCreate();

            return View(trackTime);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {                
                TrackTimeNG trackTimeNG = new TrackTimeNG();
                TrackTime trackTime = new TrackTime();

                trackTime.Id = Convert.ToInt32(collection["Id"]);
                trackTime.IdTrack = Convert.ToInt32(collection["IdTrack"]);
                trackTime.IdCar = Convert.ToInt32(collection["IdCar"]);                                
                trackTime.BestTimeLap = TimeSpan.Parse(collection["BestTimeLap"].ToString());
                trackTime.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackTimeNG.SetTrackTime(trackTime);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            TrackTimeNG trackTimeNG = new TrackTimeNG();
            TrackTime trackTime;

            trackTime = await trackTimeNG.GetTrackTime(id);

            return View(trackTime);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                
                TrackTimeNG trackTimeNG = new TrackTimeNG();
                TrackTime trackTime = new TrackTime();

                trackTime.Id = Convert.ToInt32(collection["Id"]);
                trackTime.IdTrack = Convert.ToInt32(collection["IdTrack"]);
                trackTime.IdCar = Convert.ToInt32(collection["IdCar"]);
                trackTime.BestTimeLap = TimeSpan.Parse(collection["BestTimeLap"].ToString());
                trackTime.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackTimeNG.SetTrackTime(trackTime);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TrackTimeNG trackTimeNG = new TrackTimeNG();
            TrackTime trackTime = new TrackTime();

            trackTime = await trackTimeNG.GetTrackTime(id);

            return View(trackTime);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TrackTimeNG trackTimeNG = new TrackTimeNG();
            TrackTime trackTime = new TrackTime();

            trackTime = await trackTimeNG.GetTrackTime(id);

            return View(trackTime);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                
                TrackTimeNG trackTimeNG = new TrackTimeNG();
                TrackTime trackTime = new TrackTime();

                trackTime.Id = id;
                trackTime.IsDeleted = true;

                int resp = await trackTimeNG.SetTrackTime(trackTime);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}