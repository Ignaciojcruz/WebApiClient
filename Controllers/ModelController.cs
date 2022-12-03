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
    public class ModelController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ModelNG modelNG = new ModelNG();
            List<Model> models = new List<Model>();

            models = await modelNG.GetModels();

            return View(models);
        }

        public async Task<ActionResult> Create()
        {
            ModelNG modelNG = new ModelNG();
            Model model = await modelNG.GetCreateModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {

                ModelNG modelNG = new ModelNG();
                Model model = new Model();

                model.Id = Convert.ToInt32(collection["Id"]);
                model.IdBrand = Convert.ToInt32(collection["IdBrand"]);
                model.Name = collection["Name"].ToString();
                model.IsDeleted = Convert.ToBoolean(collection["IsDeleted"].ToString().Contains("true"));

                int resp = await modelNG.SetModel(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            ModelNG modelNG = new ModelNG();
            Model model;

            model = await modelNG.GetModel(id);

            return View(model);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {

                ModelNG modelDAL = new ModelNG();
                Model model = new Model();

                model.Id = Convert.ToInt32(collection["Id"]);
                model.IdBrand = Convert.ToInt32(collection["IdBrand"]);
                model.Name = collection["Name"].ToString();
                model.IsDeleted = Convert.ToBoolean(collection["IsDeleted"].ToString().Contains("true"));

                int resp = await modelDAL.SetModel(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            ModelNG modelNG = new ModelNG();
            Model model = new Model();

            model = await modelNG.GetModel(id);

            return View(model);
        }

        public async Task<ActionResult> Delete(int id)
        {
            ModelNG modelDAL = new ModelNG();
            Model model = new Model();

            model = await modelDAL.GetModel(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                ModelNG modelNG = new ModelNG();
                Model model = new Model();

                model.Id = id;
                model.IsDeleted = true;

                int resp = await modelNG.SetModel(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}