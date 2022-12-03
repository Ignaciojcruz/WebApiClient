using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Negocio
{
    public class ModelNG
    {
        public async Task<List<Model>> GetModels()
        {
            ModelDAL modelDAL = new ModelDAL();
            List<Model> modelList = new List<Model>();

            BrandDAL brandDAL = new BrandDAL();
            List<Brand> brandList;

            modelList = await modelDAL.GetModels();
            brandList = await brandDAL.GetBrands();

            var result = from m in modelList
                         join b in brandList on m.IdBrand equals b.Id
                         select new
                         {
                             m.Id,
                             m.IdBrand,
                             NameBrand = b.Name,
                             m.Name,
                             m.IsDeleted
                         };

            List<Model> models = new List<Model>();
            foreach (var item in result)
            {
                Model m = new Model();
                m.Id = item.Id;
                m.IdBrand = item.IdBrand;
                m.NameBrand = item.NameBrand;
                m.Name = item.Name;
                m.IsDeleted = item.IsDeleted;   
                models.Add(m);
            }

            return models;

        }

        public async Task<int> SetModel(Model model)
        {
            ModelDAL modelDAL = new ModelDAL();
            return await modelDAL.SetModel(model);
        }

        public async Task<Model> GetModel(int id)
        {
            ModelDAL modelDAL = new ModelDAL();
            
            Model model;
            List<Model> modelList = await GetModels();

            model = modelList.First(m => m.Id == id);

            model.BrandList = await GetBrandSelectList();

            return model;
        }

        public async Task<Model> GetCreateModel()
        {
            Model model = new Model();

            model.BrandList = await GetBrandSelectList();

            return model;
        }

        public async Task<List<SelectListItem>> GetBrandSelectList()
        {
            BrandDAL brandDAL = new BrandDAL();
            List<Brand> brands = await brandDAL.GetBrands();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Brand b in brands)
            {
                listItem.Add(new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                });
            }

            return listItem;
        }
    }
}