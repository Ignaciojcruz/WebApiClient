using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.DAL
{
    public class ModelDAL
    {
        string Baseurl = ConfigurationManager.AppSettings["UrlApi"];
        string modelUrl = "api/Model";

        public async Task<List<Model>> GetModels()
        {
            List<Model> models = new List<Model>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(modelUrl); //

                if (Res.IsSuccessStatusCode)
                {
                    var modelResponse = Res.Content.ReadAsStringAsync().Result;
                    models = JsonConvert.DeserializeObject<List<Model>>(modelResponse);//
                }
            }

            return models;
        }

        public async Task<Model> GetModel(int id)
        {
            Model model = new Model();
            model.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(modelUrl + "?id=" + id.ToString());

                if (res.IsSuccessStatusCode)
                {
                    var modelResponse = res.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<Model>(modelResponse);
                }
            }
            return model;
        }

        public async Task<int> SetModel(Model model)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + modelUrl);
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var modelResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }
    }
}