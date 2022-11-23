using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.DAL
{
    public class TrackDAL
    {
        string Baseurl = "http://localhost:62451/";
        public async Task<List<Track>> GetTracks()
        {
            List<Track> tracks = new List<Track>(); 

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Track"); //

                if (Res.IsSuccessStatusCode)
                {
                    var TrackResponse = Res.Content.ReadAsStringAsync().Result;
                    tracks = JsonConvert.DeserializeObject<List<Track>>(TrackResponse);//
                }
            }

            return tracks; //
        }

        public async Task<Track> GetTrack(int id)
        {
            Track track = new Track();
            track.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Track?id=" + id.ToString());

                if (res.IsSuccessStatusCode)
                {
                    var TrackResponse = res.Content.ReadAsStringAsync().Result;
                    track = JsonConvert.DeserializeObject<Track>(TrackResponse);
                }
            }
            return track;
        }

        public async Task<int> SetTrack(Track track)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(track);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Track");
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var trackResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }
    }
}