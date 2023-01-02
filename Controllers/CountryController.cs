using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.Negocio;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Controllers
{
    public class CountryController : Controller
    {
        public async Task<ActionResult> Index()
        {
            CountryNG countryNG = new CountryNG();
            List<Country> countrys = new List<Country>();

            countrys = await countryNG.GetCountrys();

            return View(countrys);
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
                CountryNG countryNG = new CountryNG();  
                Country country = new Country();

                country.Id = Convert.ToInt32(collection["Id"]);
                country.Name = collection["Name"].ToString();                
                country.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await countryNG.SetCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            CountryNG countryNG = new CountryNG();
            Country country;

            country = await countryNG.GetCountry(id);

            return View(country);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {

                CountryNG countryNG = new CountryNG();
                Country country = new Country();

                country.Id = Convert.ToInt32(collection["Id"]);
                country.Name = collection["Name"].ToString();                
                country.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await countryNG.SetCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            CountryNG countryNG = new CountryNG();
            Country country = new Country();

            country = await countryNG.GetCountry(id);

            return View(country);
        }

        public async Task<ActionResult> Delete(int id)
        {
            CountryNG countryNG = new CountryNG();
            Country country = new Country();

            country = await countryNG.GetCountry(id);

            return View(country);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                CountryNG countryNG = new CountryNG();
                Country country = new Country();

                country.Id = id;
                country.IsDeleted = true;

                int resp = await countryNG.SetCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}