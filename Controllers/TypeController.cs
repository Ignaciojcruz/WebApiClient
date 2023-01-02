using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.Negocio;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Controllers
{
    public class TypeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TypeNG typeNG = new TypeNG();
            List<Type> types;

            types = await typeNG.GetTypes();

            return View(types);
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
                TypeNG typeNG = new TypeNG();
                Type type = new Type();

                type.Id = System.Convert.ToInt32(collection["Id"]);                
                type.Name = collection["Name"].ToString();
                type.IsDeleted = System.Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await typeNG.SetType(type);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            TypeNG typeNG = new TypeNG();
            Type type;

            type = await typeNG.GetType(id);

            return View(type);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {

                TypeNG typeNG = new TypeNG();
                Type type = new Type();

                type.Id = System.Convert.ToInt32(collection["Id"]);
                type.Name = collection["Name"].ToString();
                type.IsDeleted = System.Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await typeNG.SetType(type);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TypeNG typeNG = new TypeNG();
            Type type = new Type();

            type = await typeNG.GetType(id);

            return View(type);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TypeNG typeNG = new TypeNG();
            Type type = new Type();

            type = await typeNG.GetType(id);

            return View(type);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                TypeNG typeNG = new TypeNG();
                Type type = new Type();

                type.Id = id;
                type.IsDeleted = true;

                int resp = await typeNG.SetType(type);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}