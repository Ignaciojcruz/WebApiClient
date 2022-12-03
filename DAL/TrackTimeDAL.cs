using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;
using System.Configuration;

namespace WebClientWebApi2.DAL
{
    public class TrackTimeDAL
    {
        string Baseurl = ConfigurationManager.AppSettings["UrlApi"];
        string modelUrl = "api/TrackTime";
        public async Task<List<TrackTime>> GetTrackTimes()
        {
            List<TrackTime> trackTimes = new List<TrackTime>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(modelUrl); //

                if (Res.IsSuccessStatusCode)
                {
                    var trackTimeResponse = Res.Content.ReadAsStringAsync().Result;
                    trackTimes = JsonConvert.DeserializeObject<List<TrackTime>>(trackTimeResponse);//
                }
            }

            return trackTimes; //
        }

        public async Task<TrackTime> GetTrackTime(int id)
        {
            TrackTime trackTime = new TrackTime();
            trackTime.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(modelUrl + "?id=" + id.ToString());


                if (res.IsSuccessStatusCode)
                {
                    var trackTimeResponse = res.Content.ReadAsStringAsync().Result;
                    trackTime = JsonConvert.DeserializeObject<TrackTime>(trackTimeResponse);
                }
            }
            return trackTime;
        }

        public async Task<int> SetTrackTime(TrackTime trackTime)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(trackTime);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + modelUrl);
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var trackTimeResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }

        public async Task<List<TrackTimeVw>> GetTrackTimeVw()
        {
            List<TrackTimeVw> list = new List<TrackTimeVw>();
            List<TrackTime> lsTT;

            //TrackDAL trackDAL = new TrackDAL();
            //List<Track> lsT = new List<Track>();

            //CarDAL carDAL = new CarDAL();
            //List<Car> lsC = new List<Car>();

            ////buscar tracktimes            
            //lsTT = await GetTrackTimes();

            ////buscar tracks
            //lsT = await trackDAL.GetTracks();

            ////buscar cars
            //lsC = await carDAL.GetCars();

            ////hacer join con linq y devolver tracktimevw
            //var result = from tt in lsTT
            //             join t in lsT on tt.IdTrack equals t.Id
            //             select new { tt.Id, tt.IdCar, t.Name, tt.BestTimeLap } into inter
            //             join c in lsC on inter.IdCar equals c.Id
            //             select new { inter.Id, c.Brand, c.Model, inter.Name, inter.BestTimeLap };

            //foreach (var item in result)
            //{
            //    TrackTimeVw ttv = new TrackTimeVw();
            //    ttv.Id = item.Id;
            //    ttv.BrandCar = item.Brand;
            //    ttv.ModelCar = item.Model;
            //    ttv.NameTrack = item.Name;
            //    ttv.BestTimeLap = item.BestTimeLap;
            //    ttv.IsDeleted = false;
            //    list.Add(ttv);
            //}
            return list;
        }

        public async Task<TrackTimeVw> GetTrackTimeVw(int id)
        {
            List<TrackTimeVw> list = new List<TrackTimeVw>();
            //List<TrackTime> lsTT;

            //TrackDAL trackDAL = new TrackDAL();
            //List<Track> lsT = new List<Track>();

            //CarDAL carDAL = new CarDAL();
            //List<Car> lsC = new List<Car>();

            ////buscar tracktimes            
            //lsTT = await GetTrackTimes();

            ////buscar tracks
            //lsT = await trackDAL.GetTracks();

            ////buscar cars
            //lsC = await carDAL.GetCars();

            ////hacer join con linq y devolver tracktimevw
            //var result = from tt in lsTT where tt.Id == id
            //             join t in lsT on tt.IdTrack equals t.Id
            //             select new { tt.Id, tt.IdTrack, tt.IdCar, t.Name, tt.BestTimeLap } into inter
            //             join c in lsC on inter.IdCar equals c.Id
            //             select new { inter.Id, inter.IdCar, c.Brand, c.Model, inter.IdTrack, inter.Name, inter.BestTimeLap }
            //             ;

            //foreach (var item in result)
            //{
            //    TrackTimeVw ttv = new TrackTimeVw();
            //    ttv.Id = item.Id;
            //    ttv.idCar = item.IdCar;
            //    ttv.BrandCar = item.Brand;
            //    ttv.ModelCar = item.Model;
            //    ttv.IdTrack = item.IdTrack;
            //    ttv.NameTrack = item.Name;
            //    ttv.BestTimeLap = item.BestTimeLap;
            //    ttv.IsDeleted = false;
            //    list.Add(ttv);
            //}
            return list.First();
        }
    }
}