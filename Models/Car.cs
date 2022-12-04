using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientWebApi2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdBrand { get; set; }
        public string NameBrand { get; set; }
        public int IdModel { get; set; }
        public string NameModel { get; set; }
        public int Year { get; set; }
        public int IdType { get; set; }
        public string NameType { get; set; }
        public bool IsDeleted { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public List<SelectListItem> ModelList { get; set; }
        public List<SelectListItem> TypeList { get; set; }
    }
}