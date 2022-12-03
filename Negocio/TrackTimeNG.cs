using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Negocio
{
    public class TrackTimeNG
    {
        public async Task<List<TrackTime>> GetTrackTimes()
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            List<TrackTime> trackTimes;

            trackTimes = await trackTimeDAL.GetTrackTimes();

            return trackTimes;
        }

        public async Task<int> SetTrackTime(TrackTime trackTime)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            return await trackTimeDAL.SetTrackTime(trackTime);
            
        }

        public async Task<TrackTime> GetTrackTime(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            TrackTime trackTime;

            List<TrackTime> trackTimesList = await trackTimeDAL.GetTrackTimes();

            trackTime = trackTimesList.First(t => t.Id == id);

            trackTime.TrackList = await GetTrackSelectList();
            trackTime.CarList = await GetCarSelectList();

            return trackTime;
        }

        public async Task<TrackTime> GetTrackTimeCreate()
        {
            TrackTime trackTime = new TrackTime();

            trackTime.TrackList = await GetTrackSelectList();

            trackTime.CarList = await GetCarSelectList();

            return trackTime;
        }

        public async Task<List<SelectListItem>> GetTrackSelectList()
        {
            TrackDAL trackDAL = new TrackDAL();
            List<Track> tracks = await trackDAL.GetTracks();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Track t in tracks)
            {
                listItem.Add(new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });
            }

            return listItem;
        }

        public async Task<List<SelectListItem>> GetCarSelectList()
        {
            CarDAL carDAL = new CarDAL();
            List<Car> cars = await carDAL.GetCars();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Car c in cars)
            {
                listItem.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.NameBrand + c.NameModel + c.Year.ToString()    
                });
            }

            return listItem;
        }


    }
}