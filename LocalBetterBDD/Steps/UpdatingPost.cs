using LocalBetterBDD.DataEntities;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace LocalBetterBDD
{
    [Binding]
    public class UpdatingPost : PostSteps
    {
        [Given(@"I have put endpoint ready with post id (.*) and new (.*)")]
        public void GivenIHavePutEndpointReadyWithPostIdAndNew(int addedId, string name)
        {
            restRequest = new RestRequest($"posts/{addedId}", Method.PUT);
            var post = new Post
            {
                id = addedId,
                title = "blabla",
                author = name
            };

            restRequest.AddJsonBody(post);
        }
        
        [When(@"I send a put request")]
        public void WhenISendAPutRequest()
        {
            restResponse = SetRestClient().Execute(restRequest);
        }
        
        [Then(@"the post should be updated and id (.*) the (.*) should be changed")]
        public void ThenThePostShouldBeUpdatedAndIdTheShouldBeChanged(int p0, string givenName)
        {
            deserializer = new JsonDeserializer();
            var output = deserializer.Deserialize<Dictionary<string, string>>(restResponse);
            Assert.That(output["author"].ToString(), Is.EqualTo(givenName));
        }
    }
}
