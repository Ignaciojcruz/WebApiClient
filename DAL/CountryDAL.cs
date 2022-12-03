using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.DAL
{
    public class CountryDAL
    {
        string Baseurl = ConfigurationManager.AppSettings["UrlApi"];
        string modelUrl = "api/Country";

        public async Task<List<Country>> GetCountrys()
        {
            List<Country> countrys = new List<Country>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(modelUrl); //

                if (Res.IsSuccessStatusCode)
                {
                    var countryResponse = Res.Content.ReadAsStringAsync().Result;
                    countrys = JsonConvert.DeserializeObject<List<Country>>(countryResponse);//
                }
            }

            return countrys;
        }

        public async Task<Country> GetCountry(int id)
        {
            Country country = new Country();
            country.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(modelUrl + "?id=" + id.ToString());

                if (res.IsSuccessStatusCode)
                {
                    var countryResponse = res.Content.ReadAsStringAsync().Result;
                    country = JsonConvert.DeserializeObject<Country>(countryResponse);
                }
            }
            return country;
        }

        public async Task<int> SetCountry(Country country)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(country);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + modelUrl);
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var countryResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }
    }
}