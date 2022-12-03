using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;
using WebClientWebApi2.DAL;
using System.Web.Mvc;

namespace WebClientWebApi2.Negocio
{
    public class BrandNG
    {
        public async Task<List<Brand>> GetBrands()
        {
            BrandDAL brandDAL = new BrandDAL();
            List<Brand> brandList;
            CountryDAL countryDAL = new CountryDAL();
            List<Country> countryList;
                        
            brandList = await brandDAL.GetBrands();
            countryList = await countryDAL.GetCountrys();

            var result = from b in brandList
                         join c in countryList on b.IdCountry equals c.Id
                         select new { b.Id,
                                      b.Name,
                                      b.IdCountry,
                                      countryName = c.Name,
                                      b.IsDeleted
                                    };

            List<Brand> brands = new List<Brand>();
            foreach (var item in result)
            {
                Brand b = new Brand();
                b.Id = item.Id;
                b.Name = item.Name;
                b.IdCountry = item.IdCountry;
                b.CountryName = item.countryName;
                b.IsDeleted = item.IsDeleted;
                brands.Add(b);
             }

            return brands;
        }

        public async Task<int> SetBrand(Brand brand)
        {            
            BrandDAL brandDAL = new BrandDAL();            
            return await brandDAL.SetBrand(brand);                        
        }

        public async Task<Brand> GetBrand(int id)
        {
            BrandDAL brandDAL = new BrandDAL();
            
            Brand brand;
            List<Brand> brandList = await GetBrands();

            brand = brandList.First(b => b.Id == id);  

            brand.CountryList = await GetCountrySelectList();
                        
            return brand;
        }
                
        public async Task<Brand> GetCreateBrand()
        {
            Brand brand = new Brand();

            brand.CountryList = await GetCountrySelectList();

            return brand;
        }

        public async Task<List<SelectListItem>> GetCountrySelectList()
        {
            CountryDAL countryDAL = new CountryDAL();
            List<Country> countrys = await countryDAL.GetCountrys();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Country c in countrys)
            {
                listItem.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            }

            return listItem;
        }
    }
}