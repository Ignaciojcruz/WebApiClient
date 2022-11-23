using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientWebApi2.Models
{
    public class TrackTime
    {
        public int Id { get; set; }
        public int IdTrack { get; set; }
        public int IdCar { get; set; }
        public TimeSpan BestTimeLap { get; set; }
        public bool IsDeleted { get; set; }
    }
}