using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Negocio
{
    public class CountryNG
    {
        public async Task<List<Country>> GetCountrys()
        {
            List<Country> list= new List<Country>();
            CountryDAL countryDAL= new CountryDAL();

            list = await countryDAL.GetCountrys();

            return list;
        }

        public async Task<int> SetCountry(Country country)
        {
            CountryDAL countryDAL = new CountryDAL();

            int resp = await countryDAL.SetCountry(country);

            return resp;
        }

        public async Task<Country> GetCountry(int id)
        {
            CountryDAL countryDAL = new CountryDAL();

            Country country;
            List<Country> countryList = await GetCountrys();

            country = countryList.First(b => b.Id == id);
                        
            return country;
        }

    }
}