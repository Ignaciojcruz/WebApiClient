using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Controllers
{
    public class CountryController : Controller
    {
        public async Task<ActionResult> Index()
        {
            CountryDAL countryDAL = new CountryDAL();
            List<Country> countrys = new List<Country>();

            countrys = await countryDAL.GetCountrys();

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

                CountryDAL countryDAL = new CountryDAL();
                Country country = new Country();

                country.Id = Convert.ToInt32(collection["Id"]);
                country.Name = collection["Name"].ToString();                
                country.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await countryDAL.SetCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            CountryDAL countryDAL = new CountryDAL();
            Country country;

            country = await countryDAL.GetCountry(id);

            return View(country);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {

                CountryDAL countryDAL = new CountryDAL();
                Country country = new Country();

                country.Id = Convert.ToInt32(collection["Id"]);
                country.Name = collection["Name"].ToString();                
                country.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await countryDAL.SetCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            CountryDAL countryDAL = new CountryDAL();
            Country country = new Country();

            country = await countryDAL.GetCountry(id);

            return View(country);
        }

        public async Task<ActionResult> Delete(int id)
        {
            CountryDAL countryDAL = new CountryDAL();
            Country country = new Country();

            country = await countryDAL.GetCountry(id);

            return View(country);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                CountryDAL countryDAL = new CountryDAL();
                Country country = new Country();

                country.Id = id;
                country.IsDeleted = true;

                int resp = await countryDAL.SetCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}