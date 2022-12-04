using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClientWebApi2.Models;
using WebClientWebApi2.DAL;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebClientWebApi2.Negocio
{
    public class CarNG
    {
        public async Task<List<Car>> GetCars()
        {
            CarDAL carDAL = new CarDAL();
            List<Car> carList;

            BrandDAL brandDAL = new BrandDAL();
            List<Brand> brandList;
            ModelDAL modelDAL = new ModelDAL();
            List<Model> modelList;
            TypeDAL typeDAL = new TypeDAL();
            List<Type> typeList;

            carList = await carDAL.GetCars();
            brandList = await brandDAL.GetBrands();
            modelList = await modelDAL.GetModels();
            typeList = await typeDAL.GetTypes();

            var result = from c in carList
                         join b in brandList on c.IdBrand equals b.Id
                         select new { c.Id, c.IdBrand, NameBrand = b.Name, c.IdModel, c.Year, c.IdType, c.IsDeleted } into res1
                         join m in modelList on res1.IdModel equals m.Id
                         select new { res1.Id, res1.IdBrand, res1.NameBrand, res1.IdModel, NameModel = m.Name, res1.Year, res1.IdType, res1.IsDeleted } into res2
                         join t in typeList on res2.IdType equals t.Id
                         select new { res2.Id, res2.IdBrand, res2.NameBrand, res2.IdModel, res2.NameModel, res2.Year, res2.IdType, NameType = t.Name, res2.IsDeleted };

            List<Car> cars = new List<Car>();
            foreach (var item in result)
            {
                Car car = new Car();
                car.Id = item.Id;
                car.Name = item.NameBrand + " " + item.NameModel + " " + item.Year.ToString();
                car.IdBrand = item.IdBrand;
                car.NameBrand = item.NameBrand;
                car.IdModel = item.IdModel;
                car.NameModel = item.NameModel;
                car.Year = item.Year;
                car.IdType = item.IdType;
                car.NameType = item.NameType;
                car.IsDeleted = item.IsDeleted;
                cars.Add(car);
            }

            return cars;


        }

        public async Task<int> SetCar(Car car)
        {
            CarDAL carDAL = new CarDAL();
            return await carDAL.SetCar(car);
        }

        public async Task<Car> GetCar(int id)
        {
            CarDAL carDAL = new CarDAL();            
            Car car;
            List<Car> carList = await GetCars();

            car = carList.First(c => c.Id == id);

            car.BrandList = await GetBrandSelectList();
            car.ModelList = await GetModelSelectList();
            car.TypeList = await GetTypeSelectList();

            return car;
        }

        public async Task<Car> GetCreateCar()
        {
            Car car = new Car();

            car.BrandList = await GetBrandSelectList();
            car.ModelList = await GetModelSelectList();
            car.TypeList = await GetTypeSelectList();

            return car;
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

        public async Task<List<SelectListItem>> GetModelSelectList()
        {
            ModelDAL modelDAL = new ModelDAL();
            List<Model> models = await modelDAL.GetModels();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Model m in models)
            {
                listItem.Add(new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                });
            }

            return listItem;
        }

        public async Task<List<SelectListItem>> GetTypeSelectList()
        {
            TypeDAL typeDAL = new TypeDAL();
            List<Type> types = await typeDAL.GetTypes();

            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (Type t in types)
            {
                listItem.Add(new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });
            }

            return listItem;
        }
    }
}