using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientWebApi2.Models
{
    public class TrackTime
    {
        public int Id { get; set; }
        public int IdTrack { get; set; }
        public string NameTrack { get; set; }
        public int IdCar { get; set; }
        public string NameCar { get; set; }
        public TimeSpan BestTimeLap { get; set; }
        public bool IsDeleted { get; set; }
        public List<SelectListItem> TrackList { get; set; }
        public List<SelectListItem> CarList { get; set; }
    }
}