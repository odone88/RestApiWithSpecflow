using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace LocalBetterBDD.Steps
{
    [Binding]
    public class RetrievingPost : PostSteps
    {
        [Given(@"I have get endpoint ready with post id (.*)")]
        public void GivenIHaveGetEndpointReadyWithPostId(int postId)
        {
            restRequest = new RestRequest($"posts/{postId}", Method.GET);
        }
        
        [When(@"I send a get request")]
        public void WhenISendAGetRequest()
        {
            restResponse = SetRestClient().Execute(restRequest);
        }
        
        [Then(@"the post with id (.*) should be retrieved without issues")]
        public void ThenThePostWithIdShouldBeRetrievedWithoutIssues(int addedId)
        {
            deserializer = new JsonDeserializer();
            var output = deserializer.Deserialize<Dictionary<string, string>>(restResponse);
            Assert.That(output["id"].ToString(), Is.EqualTo(addedId.ToString()));
        }
    }
}
