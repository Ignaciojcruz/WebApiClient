using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.Models;
using WebClientWebApi2.DAL;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebClientWebApi2.Controllers
{
    public class CarController : Controller
    {
        string Baseurl = "http://localhost:62451/";
        // GET: Car
        public async Task<ActionResult> Index()
        {
            CarDAL carDAL = new CarDAL();
            List<Car> cars = new List<Car>();

            cars = await carDAL.GetCars();
            //List<Car> cars = new List<Car>();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();

            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage Res = await client.GetAsync("api/Car");

            //    if (Res.IsSuccessStatusCode)
            //    {
            //        var CarResponse = Res.Content.ReadAsStringAsync().Result;
            //        cars = JsonConvert.DeserializeObject<List<Car>>(CarResponse);
            //    }

            //}

            return View(cars);
        }

        
    }

}