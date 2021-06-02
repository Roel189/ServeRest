using ClassLibrary1.Data;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Demo
    {
        public User GetUser()
        {
            var restClient = new RestClient("https://serverest.dev/");
            var restRequest = new RestRequest("usuarios", Method.GET);

            restRequest.AddHeader("Accept", "application/json");
            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            User users = JsonConvert.DeserializeObject<User>(content);
            return users;
        }
    }
}
