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
    public class BrandController : Controller
    {

        public async Task<ActionResult> Index()
        {
            BrandDAL brandDAL = new BrandDAL();
            List<Brand> brands = new List<Brand>();

            brands = await brandDAL.GetBrands();

            return View(brands);
        }
    }
}