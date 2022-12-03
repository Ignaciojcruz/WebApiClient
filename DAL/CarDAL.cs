using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        string Baseurl = ConfigurationManager.AppSettings["UrlApi"];
        string modelUrl = "api/Car";
        public async Task<List<Car>> GetCars()
        {
            List<Car> cars = new List<Car>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(modelUrl); //

                if (Res.IsSuccessStatusCode)
                {
                    var CarResponse = Res.Content.ReadAsStringAsync().Result;
                    cars = JsonConvert.DeserializeObject<List<Car>>(CarResponse);//
                }
            }

            return cars; //
        }

        public async Task<Car> GetCar(int id)
        {
            Car car = new Car();
            car.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(modelUrl + "?id=" + id.ToString());


                if (res.IsSuccessStatusCode)
                {
                    var CarResponse = res.Content.ReadAsStringAsync().Result;
                    car = JsonConvert.DeserializeObject<Car>(CarResponse);
                }
            }
            return car;
        }

        public async Task<int> SetCar(Car car)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(car);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Car");
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var carResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }
    }
}