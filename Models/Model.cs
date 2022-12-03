using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientWebApi2.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public string NameBrand { get; set; }
        public string Name { get; set; }
        public bool IsDeleted {get; set; }

        public List<SelectListItem> BrandList { get; set; }
    }
}