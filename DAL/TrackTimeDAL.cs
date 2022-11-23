﻿using Newtonsoft.Json;
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
    public class TrackTimeDAL
    {
        string Baseurl = "http://localhost:62451/";
        public async Task<List<TrackTime>> GetTrackTimes()
        {
            List<TrackTime> trackTimes = new List<TrackTime>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/TrackTime"); //

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

                HttpResponseMessage res = await client.GetAsync("api/TrackTime?id=" + id.ToString());


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

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/TrackTime");
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
    }
}