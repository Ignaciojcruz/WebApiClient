using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.Models;
using WebClientWebApi2.Negocio;

namespace WebClientWebApi2.Controllers
{
    public class BrandController : Controller
    {

        public async Task<ActionResult> Index()
        {
            BrandNG brandNG = new BrandNG();
            List<Brand> brands = new List<Brand>();

            brands = await brandNG.GetBrands();

            return View(brands);
        }

        public async Task<ActionResult> Create()
        {
            BrandNG brandNG = new BrandNG();
            Brand brand = await brandNG.GetCreateBrand();

            return View(brand);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                BrandNG brandNG = new BrandNG();
                Brand brand = new Brand();

                brand.Id = Convert.ToInt32(collection["Id"]);
                brand.Name = collection["Name"].ToString();
                brand.IdCountry = Convert.ToInt32(collection["IdCountry"]);
                brand.IsDeleted = Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await brandNG.SetBrand(brand);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            BrandNG brandNG = new BrandNG();
            Brand brand;

            brand = await brandNG.GetBrand(id);

            return View(brand);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {

                BrandNG brandNG = new BrandNG();
                Brand brand = new Brand();

                brand.Id = Convert.ToInt32(collection["Id"]);
                brand.Name = collection["Name"].ToString();
                brand.IdCountry = Convert.ToInt32(collection["IdCountry"]);                                
                brand.IsDeleted = Convert.ToBoolean(collection["IsDeleted"].ToString().Contains("true"));

                int resp = await brandNG.SetBrand(brand);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            BrandNG brandNG = new BrandNG();
            Brand brand = new Brand();

            brand = await brandNG.GetBrand(id);

            return View(brand);
        }

        public async Task<ActionResult> Delete(int id)
        {
            BrandNG brandNG = new BrandNG();
            Brand brand;

            brand = await brandNG.GetBrand(id);

            return View(brand);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                BrandNG brandNG = new BrandNG();
                Brand brand = new Brand();

                brand.Id = id;
                brand.IsDeleted = true;

                int resp = await brandNG.SetBrand(brand);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}