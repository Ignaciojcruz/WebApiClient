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
            List<TrackTime> trackTimeList;

            trackTimeList = await trackTimeDAL.GetTrackTimes();

            CarNG carNG = new CarNG();
            List<Car> carList = await carNG.GetCars();
            TrackDAL trackDAL = new TrackDAL();
            List<Track> trackList = await trackDAL.GetTracks();

            var result = from tt in trackTimeList
                         join c in carList on tt.IdCar equals c.Id
                         select new { tt.Id, tt.IdCar, NameCar = c.Name, tt.IdTrack, tt.BestTimeLap, tt.IsDeleted } into res1
                         join t in trackList on res1.IdTrack equals t.Id
                         select new { res1.Id, res1.IdCar, res1.NameCar, res1.IdTrack, NameTrack = t.Name, res1.BestTimeLap, res1.IsDeleted };

            List<TrackTime> trackTimes = new List<TrackTime>();
            foreach (var item in result)
            {
                TrackTime tt = new TrackTime();
                tt.Id = item.Id;
                tt.IdCar = item.IdCar;
                tt.NameCar = item.NameCar;
                tt.IdTrack = item.IdTrack;
                tt.NameTrack = item.NameTrack;
                tt.BestTimeLap = item.BestTimeLap;
                tt.IsDeleted = item.IsDeleted;
                trackTimes.Add(tt);
            }

            return trackTimes;
        }

        public async Task<int> SetTrackTime(TrackTime trackTime)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            return await trackTimeDAL.SetTrackTime(trackTime);            
        }

        public async Task<TrackTime> GetTrackTime(int id)
        {
            
            TrackTime trackTime;

            List<TrackTime> trackTimesList = await GetTrackTimes();

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
            CarNG carNG = new CarNG();
            List<Car> cars = await carNG.GetCars();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Car c in cars)
            {
                listItem.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }); ;
            }

            return listItem;
        }


    }
}