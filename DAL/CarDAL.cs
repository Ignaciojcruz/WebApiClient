using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.DAL
{
    public class CarDAL
    {
        string Baseurl = "http://localhost:62451/";
        public async Task<List<Car>> GetCars()
        {
            List<Car> cars = new List<Car>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Car");

                if(Res.IsSuccessStatusCode)
                {
                    var CarResponse = Res.Content.ReadAsStringAsync().Result;
                    cars = JsonConvert.DeserializeObject<List<Car>>(CarResponse);
                }

            }
            return cars;
        }
    }
}