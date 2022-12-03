using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebClientWebApi2.Models;
using System.Configuration;


namespace WebClientWebApi2.DAL
{
    public class TypeDAL
    {
        string Baseurl = ConfigurationManager.AppSettings["UrlApi"];
        string modelUrl = "api/Type";

        public async Task<List<Type>> GetTypes()
        {
            List<Type> types = new List<Type>(); //

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(modelUrl); //

                if (Res.IsSuccessStatusCode)
                {
                    var typeResponse = Res.Content.ReadAsStringAsync().Result;
                    types = JsonConvert.DeserializeObject<List<Type>>(typeResponse);//
                }
            }

            return types;
        }

        public async Task<Type> GetType(int id)
        {
            Type type = new Type();
            type.Id = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(modelUrl + "?id=" + id.ToString());

                if (res.IsSuccessStatusCode)
                {
                    var typeResponse = res.Content.ReadAsStringAsync().Result;
                    type = JsonConvert.DeserializeObject<Type>(typeResponse);
                }
            }
            return type;
        }

        public async Task<int> SetType(Type type)
        {
            int resp = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                var json = JsonConvert.SerializeObject(type);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Baseurl + modelUrl);
                request.Content = content;

                HttpResponseMessage res = await client.SendAsync(request);

                if (res.IsSuccessStatusCode)
                {
                    var typeResponse = res.Content.ReadAsStringAsync().Result;
                    resp = 1;
                }

            }

            return resp;
        }
    }
}