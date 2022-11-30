using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientWebApi2.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public bool IsDeleted { get; set; }
    }
}