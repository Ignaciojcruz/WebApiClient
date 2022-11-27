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
    public class TrackTimeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            List<TrackTime> trackTimes = new List<TrackTime>();

            trackTimes = await trackTimeDAL.GetTrackTimes();

            //TODO - retornar TrackTimeVw

            return View(trackTimes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
                TrackTime trackTime = new TrackTime();

                trackTime.Id = Convert.ToInt32(collection["Id"]);
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

        public async Task<ActionResult> Edit(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            TrackTime trackTime;

            trackTime = await trackTimeDAL.GetTrackTime(id);

            return View(trackTime);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
                TrackTime trackTime = new TrackTime();

                trackTime.Id = Convert.ToInt32(collection["Id"]);
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
            TrackTime trackTime = new TrackTime();

            trackTime = await trackTimeDAL.GetTrackTime(id);

            return View(trackTime);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            TrackTime trackTime = new TrackTime();

            trackTime = await trackTimeDAL.GetTrackTime(id);

            return View(trackTime);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
                TrackTime trackTime = new TrackTime();

                trackTime.Id = id;
                trackTime.IsDeleted = true;

                int resp = await trackTimeDAL.SetTrackTime(trackTime);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}