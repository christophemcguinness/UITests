using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using APITests.Objects;
using Newtonsoft;
using Newtonsoft.Json;

namespace APITests.StepDefs
{
    [Binding]
    public sealed class APITests
    {
    
        private ScenarioContext context;

        public APITests(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


        [Given(@"Set the API EndPoint to ""(.*)""")]
        public void GivenSetTheAPIEndPointTo(string endPoint)
        {
            IRestClient restClient = new RestClient("https://reqres.in/"+endPoint);
            //context.Add("RestClient",restClient);
            //context.Set<RestClient>(restClient);
            context.Set<IRestClient>(restClient, "RestClient");
        }

        [Given(@"Set the Request Type as GET")]
        public void GivenSetTheRequestTypeAsGET()
        {
            IRestRequest request = new RestRequest(Method.GET);
            context.Set<IRestRequest>(request, "Request");
            //context.Add("Request",request);
        }


        [Given(@"Execute the request call")]
        public void GivenExecuteTheRequestCall()
        {
            IRestResponse response = context.Get<IRestClient>("RestClient").Execute(context.Get<IRestRequest>("Request"));
            context.Set<IRestResponse>(response, "Response");
        }

        [Then(@"Check Status Code is (.*)")]
        public void ThenCheckStatusCodeIs(int expectStatus)
        {
            
            int acutalStatusCode = (int)context.Get<IRestResponse>("Response").StatusCode;
            Assert.AreEqual(expectStatus, acutalStatusCode, "Status not as expected expected status was " + expectStatus + " but actual was " + acutalStatusCode);

        }

        [Then(@"Check number of user is (.*)")]
        public void ThenCheckNumberOfUserIs(int userCount)
        {
         
            UserList userList = JsonConvert.DeserializeObject<UserList>((string)context.Get<IRestResponse>("Response").Content);

            Assert.AreEqual(userCount, userList.per_page, "Status not as expected expected status was " + userCount + " but actual was " + userList.per_page);
        }

        [Then(@"Check Users name is ""(.*)""")]
        public void ThenCheckUsersNameIs(string userName)
        {

            PutUpdate updateResponse = JsonConvert.DeserializeObject<PutUpdate>((string)context.Get<IRestResponse>("Response").Content);

            Assert.AreEqual(userName, updateResponse.name, "Status not as expected expected status was " + userName + " but actual was " + updateResponse.name);

        }

        [Then(@"Check Users first name is ""(.*)""")]
        public void ThenCheckUsersFirstNameIs(string userName)
        {
            SingleUser user = JsonConvert.DeserializeObject<SingleUser>((string)context.Get<IRestResponse>("Response").Content);

            Assert.AreEqual(userName, user.data.first_name, "Status not as expected expected status was " + userName + " but actual was " + user.data.first_name);


        }


        [Given(@"Set the Request Type as Post")]
        public void GivenSetTheRequestTypeAsPost()
        {
            IRestRequest request = new RestRequest(Method.POST);
            context.Set<IRestRequest>(request, "Request");
        }

        [Given(@"I set body to ""(.*)"" is ""(.*)"" and ""(.*)"" is ""(.*)""")]
        public void GivenISetBodyToIsAndIs(string val1, string val2, string val3, string val4)
        {
            context.Set<IRestRequest>(context.Get<IRestRequest>("Request").AddParameter(val1, val2), "Request");
            context.Set<IRestRequest>(context.Get<IRestRequest>("Request").AddParameter(val3, val4), "Request");
        }

        [Given(@"Set the Request Type as Put")]
        public void GivenSetTheRequestTypeAsPut()
        {
            IRestRequest request = new RestRequest(Method.PUT);
            context.Set<IRestRequest>(request, "Request");
        }

        [Given(@"Set the Request Type as Delete")]
        public void GivenSetTheRequestTypeAsDelete()
        {
            IRestRequest request = new RestRequest(Method.DELETE);
            context.Set<IRestRequest>(request, "Request");
        }

        [Then(@"Then check id is (.*)")]
        public void ThenThenCheckIdIs(int idCode)
        {
            RegisterModel registerModel = JsonConvert.DeserializeObject<RegisterModel>((string)context.Get<IRestResponse>("Response").Content);

            Assert.AreEqual(idCode, registerModel.id, "Status not as expected expected status was " + idCode + " but actual was " + registerModel.id);

        }

        [Then(@"Then check token is not null")]
        public void ThenThenCheckTokenIsNotNull()
        {
            LoginModel login = JsonConvert.DeserializeObject<LoginModel>((string)context.Get<IRestResponse>("Response").Content);

            Assert.IsNotNull(login.token, "Item is null");
        }


    }
}
