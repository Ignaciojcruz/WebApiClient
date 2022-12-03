using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Controllers
{
    public class TypeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TypeDAL typeDAL = new TypeDAL();
            List<Type> types;

            types = await typeDAL.GetTypes();

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
                TypeDAL typeDAL = new TypeDAL();
                Type type = new Type();

                type.Id = System.Convert.ToInt32(collection["Id"]);                
                type.Name = collection["Name"].ToString();
                type.IsDeleted = System.Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await typeDAL.SetType(type);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            TypeDAL typeDAL = new TypeDAL();
            Type type;

            type = await typeDAL.GetType(id);

            return View(type);
        }

        // POST: Prueba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {

                TypeDAL typeDAL = new TypeDAL();
                Type type = new Type();

                type.Id = System.Convert.ToInt32(collection["Id"]);
                type.Name = collection["Name"].ToString();
                type.IsDeleted = System.Convert.ToBoolean(collection["IsDeleted"]);

                int resp = await typeDAL.SetType(type);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TypeDAL typeDAL = new TypeDAL();
            Type type = new Type();

            type = await typeDAL.GetType(id);

            return View(type);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TypeDAL typeDAL = new TypeDAL();
            Type type = new Type();

            type = await typeDAL.GetType(id);

            return View(type);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                TypeDAL typeDAL = new TypeDAL();
                Type type = new Type();

                type.Id = id;
                type.IsDeleted = true;

                int resp = await typeDAL.SetType(type);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}