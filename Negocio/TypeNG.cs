
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebClientWebApi2.DAL;
using WebClientWebApi2.Models;

namespace WebClientWebApi2.Negocio
{
    public class TypeNG
    {
        public async Task<List<Type>> GetTypes()
        {
            TypeDAL typeDAL = new TypeDAL();
            List<Type> types;

            types = await typeDAL.GetTypes();

            return types;
        }

        public async Task<int> SetType(Type type)
        {
            TypeDAL typeDAL = new TypeDAL();
            int resp = await typeDAL.SetType(type);

            return resp;
        }

        public async Task<Type> GetType(int id)
        {
            TypeDAL typeDAL = new TypeDAL();
            Type type;

            type = await typeDAL.GetType(id);

            return type;
        }
    }
}