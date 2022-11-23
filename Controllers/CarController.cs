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
                
        public async Task<ActionResult> Index()
        {
            CarDAL carDAL = new CarDAL();
            List<Car> cars = new List<Car>();

            cars = await carDAL.GetCars();
            
            return View(cars);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CarDAL carDAL = new CarDAL();
                Car car = new Car();

                car.Id = Convert.ToInt32(collection["Id"]);
                car.Brand = collection["Brand"].ToString();
                car.Model = collection["Model"].ToString();
                car.Year = Convert.ToInt32(collection["Year"]);
                car.Type = collection["Type"].ToString();
                car.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await carDAL.SetCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            CarDAL carDAL = new CarDAL();
            Car car = new Car();

            car = await carDAL.GetCar(id);

            return View(car);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CarDAL carDAL = new CarDAL();
                Car car = new Car();

                car.Id = Convert.ToInt32(collection["Id"]);
                car.Brand = collection["Brand"].ToString();
                car.Model = collection["Model"].ToString();
                car.Year = Convert.ToInt32(collection["Year"]);
                car.Type = collection["Type"].ToString();
                car.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await carDAL.SetCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            CarDAL carDAL = new CarDAL();
            Car car = new Car();

            car = await carDAL.GetCar(id);

            return View(car);
        }

        public async Task<ActionResult> Delete(int id)
        {
            CarDAL carDAL = new CarDAL();
            Car car = new Car();

            car = await carDAL.GetCar(id);

            return View(car);
        }

        // POST: Prueba/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CarDAL carDAL = new CarDAL();
                Car car = new Car();

                car.Id = id;
                car.IsDeleted = true;

                int resp = await carDAL.SetCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}