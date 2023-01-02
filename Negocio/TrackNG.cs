using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;
using WebClientWebApi2.DAL;

namespace WebClientWebApi2.Negocio
{
    public class TrackNG
    {
        public TrackNG() { }

        public async Task<List<Track>> GetTracks()
        {
            TrackDAL trackDAL = new TrackDAL();
            List<Track> tracks;

            tracks = await trackDAL.GetTracks();

            return tracks;
        }

        public async Task<int> SetTrack(Track track)
        {
            TrackDAL trackDAL = new TrackDAL();
            int resp = await trackDAL.SetTrack(track);

            return resp;
        }

        public async Task<Track> GetTrack(int id)
        {
            TrackDAL trackDAL = new TrackDAL();
            Track track;

            track = await trackDAL.GetTrack(id);

            return track;
        }
    }
}