using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.Models;
using WebClientWebApi2.Negocio;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebClientWebApi2.Controllers
{
    public class CarController : Controller
    {
                
        public async Task<ActionResult> Index()
        {
            CarNG carNG = new CarNG();
            List<Car> cars = new List<Car>();

            cars = await carNG.GetCars();
            
            return View(cars);
        }

        public async Task<ActionResult> Create()
        {
            CarNG carNG = new CarNG();
            Car car = await carNG.GetCreateCar();
            return View(car);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                
                CarNG carNG = new CarNG();
                Car car = new Car();

                car.Id = Convert.ToInt32(collection["Id"]);
                car.IdBrand = Convert.ToInt32(collection["IdBrand"].ToString());
                car.IdModel = Convert.ToInt32(collection["IdModel"].ToString());
                car.Year = Convert.ToInt32(collection["Year"]);
                car.IdType = Convert.ToInt32(collection["IdType"].ToString());
                car.IsDeleted = Convert.ToBoolean(collection["IsDeleted"].ToString().Contains("true"));

                int resp = await carNG.SetCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            CarNG carNG = new CarNG();
            Car car;

            car = await carNG.GetCar(id);

            return View(car);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                
                CarNG carNG = new CarNG();
                Car car = new Car();

                car.Id = Convert.ToInt32(collection["Id"]);
                car.IdBrand = Convert.ToInt32(collection["IdBrand"].ToString());
                car.IdModel = Convert.ToInt32(collection["IdModel"].ToString());
                car.Year = Convert.ToInt32(collection["Year"]);
                car.IdType = Convert.ToInt32(collection["IdType"].ToString());
                car.IsDeleted = Convert.ToBoolean(collection["IsDeleted"].ToString().Contains("true"));

                int resp = await carNG.SetCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            CarNG carNG = new CarNG();
            Car car = new Car();

            car = await carNG.GetCar(id);

            return View(car);
        }

        public async Task<ActionResult> Delete(int id)
        {
            CarNG carNG = new CarNG();
            Car car = new Car();

            car = await carNG.GetCar(id);

            return View(car);
        }
                
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                
                CarNG carNG = new CarNG();
                Car car = new Car();

                car.Id = id;
                car.IsDeleted = true;

                int resp = await carNG.SetCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}