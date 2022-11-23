using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientWebApi2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}