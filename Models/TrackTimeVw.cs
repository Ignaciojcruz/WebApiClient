using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientWebApi2.Models
{
    public class TrackTimeVw
    {
        public int Id { get; set; }

        public int idCar { get; set; }
        public string BrandCar { get; set; }
        public string ModelCar { get; set; }

        public int IdTrack { get; set; }
        public string NameTrack { get; set; }        
        public TimeSpan BestTimeLap { get; set; }
        public bool IsDeleted { get; set; }
    }
}