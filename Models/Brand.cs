﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientWebApi2.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
        public bool IsDeleted { get; set; }
        public List<SelectListItem> CountryList { get; set; }
    }
}