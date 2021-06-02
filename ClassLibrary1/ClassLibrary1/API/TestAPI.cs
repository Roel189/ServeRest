using ClassLibrary1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.API
{
    [TestClass]
    public class TestAPI
    {
        private string id=null;

        [TestMethod]
        public void CreateUsers()
        {
            string jsonString = @"{
                                  ""nome"": ""Maria"",
                                  ""email"": ""maria@aa.com.br"",
                                  ""password"": ""teste"",
                                  ""administrador"": ""true""

                               }";
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restUrl = restApi.SetUrl("usuarios");
            var restRequest = restApi.CreatePostRequest(jsonString);
            var response = restApi.GetResponse(restUrl, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);

            Assert.AreEqual(content.message, "Cadastro realizado com sucesso");
            id = content._id;
            VerifyUser(id);
        }

        public void VerifyUser(string id)
        {
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restUrl = restApi.SetUrlWithId("usuarios/",id);
            var restRequest = restApi.CreateGetRequest();
            var response = restApi.GetResponse(restUrl, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);

            Assert.AreEqual(content.nome, "Maria");
            Assert.AreEqual(content.email, "maria@aa.com.br");
            Assert.AreEqual(content.password, "teste");
            Assert.AreEqual(content.administrador, "true");

            id = content._id;
        }
        [TestMethod]
        public void EditUsers()
        {
            string jsonString = @"{
                                  ""nome"": ""Selva da Mata"",
                                  ""email"": ""fulano@roel.com.br"",
                                  ""password"": ""teste123"",
                                  ""administrador"": ""true""

                               }";
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restId = restApi.SetUrlWithId("usuarios", "6HvGeId1J6MiQC7H");
            var restRequest = restApi.CreatePutRequest(jsonString);
            var response = restApi.GetResponse(restId, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);

            Assert.AreEqual(content.message, "Registro alterado com sucesso");
       

        }
        [TestMethod]
        public void DeleteUsers()
        {
    
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restId = restApi.SetUrlWithId("usuarios", "i4kwdNg1R0RQ8Fbv");
            var restRequest = restApi.CreateDeleteRequest();
            var response = restApi.GetResponse(restId, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);
            Assert.AreEqual(content.message, "Registro excluído com sucesso");


        }

        [TestMethod]
        public void GetListUsers()
        {

            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restId = restApi.SetUrl("usuarios");
            var restRequest = restApi.CreateGetRequest();
            var response = restApi.GetResponse(restId, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);
        }


    }
}
