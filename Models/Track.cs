using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientWebApi2.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public bool IsDeleted { get; set; }
    }
}