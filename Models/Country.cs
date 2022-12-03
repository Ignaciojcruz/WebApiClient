using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebClientWebApi2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public bool IsDeleted { get; set; }

    }
}