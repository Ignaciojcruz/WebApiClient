using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;
using System.Configuration;


namespace WebClientWebApi2.DAL
{
    public class BrandDAL
    {
        string Baseurl = ConfigurationManager.AppSettings["UrlApi"];
        string modelUrl = "api/Brand";

        public async Task<List<Brand>> GetBrands()
        {
            List<Brand> brands = new List<Brand>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(modelUrl); //

                if (Res.IsSuccessStatusCode)
                {
                    var brandResponse = Res.Content.ReadAsStringAsync().Result;
                    brands = JsonConvert.DeserializeObject<List<Brand>>(brandResponse);//
                }
            }

            return brands; 
        }

        public async Task<Brand> GetBrand(int id)
        {
            Brand brand = new Brand();
            brand.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(modelUrl + "?id=" + id.ToString());

                if (res.IsSuccessStatusCode)
                {
                    var brandResponse = res.Content.ReadAsStringAsync().Result;
                    brand = JsonConvert.DeserializeObject<Brand>(brandResponse);
                }
            }
            return brand;
        }

        public async Task<int> SetBrand(Brand brand)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(brand);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + modelUrl);
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var brandResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }
    }
}