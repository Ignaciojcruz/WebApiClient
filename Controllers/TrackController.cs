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
    public class TrackController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TrackNG trackNG = new TrackNG();
            List<Track> tracks;

            tracks = await trackNG.GetTracks();

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
                
                TrackNG trackNG = new TrackNG();
                Track track = new Track();

                track.Id = Convert.ToInt32(collection["Id"]);
                track.Name = collection["Name"].ToString();                
                track.Length = Convert.ToInt32(collection["Length"]);                
                track.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackNG.SetTrack(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            TrackNG trackNG = new TrackNG();
            Track track;

            track = await trackNG.GetTrack(id);

            return View(track);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                
                TrackNG trackNG = new TrackNG();
                Track track = new Track();

                track.Id = Convert.ToInt32(collection["Id"]);
                track.Name = collection["Name"].ToString();                
                track.Length = Convert.ToInt32(collection["Length"]);                
                track.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await trackNG.SetTrack(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TrackNG trackNG = new TrackNG();
            Track track = new Track();

            track = await trackNG.GetTrack(id);

            return View(track);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TrackNG trackNG = new TrackNG();
            Track track = new Track();

            track = await trackNG.GetTrack(id);

            return View(track);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                
                TrackNG trackNG = new TrackNG();
                Track track = new Track();

                track.Id = id;
                track.IsDeleted = true;

                int resp = await trackNG.SetTrack(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}