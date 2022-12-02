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
    public class TrackController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TrackDAL trackDAL = new TrackDAL();
            List<Track> tracks = new List<Track>();

            tracks = await trackDAL.GetTracks();

            return View(tracks);
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
                
                TrackDAL trackDAL = new TrackDAL();
                Track track = new Track();

                track.Id = Convert.ToInt32(collection["Id"]);
                track.Name = collection["Name"].ToString();                
                track.Length = Convert.ToInt32(collection["Length"]);                
                track.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackDAL.SetTrack(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            TrackDAL trackDAL = new TrackDAL();
            Track track;

            track = await trackDAL.GetTrack(id);

            return View(track);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                
                TrackDAL trackDAL = new TrackDAL();
                Track track = new Track();

                track.Id = Convert.ToInt32(collection["Id"]);
                track.Name = collection["Name"].ToString();                
                track.Length = Convert.ToInt32(collection["Length"]);                
                track.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackDAL.SetTrack(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TrackDAL trackDAL = new TrackDAL();
            Track track = new Track();

            track = await trackDAL.GetTrack(id);

            return View(track);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TrackDAL trackDAL = new TrackDAL();
            Track track = new Track();

            track = await trackDAL.GetTrack(id);

            return View(track);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                
                TrackDAL trackDAL = new TrackDAL();
                Track track = new Track();

                track.Id = id;
                track.IsDeleted = true;

                int resp = await trackDAL.SetTrack(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}