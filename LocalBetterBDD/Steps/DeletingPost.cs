using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace LocalBetterBDD.Steps
{
    [Binding]
    public class DeletingPost : PostSteps
    {
        [Given(@"I have delete endpoint ready with post id (.*)")]
        public void GivenIHaveDeleteEndpointReadyWithPostId(int postId)
        {
            restRequest = new RestRequest($"posts/{postId}", Method.DELETE);
        }
        
        [When(@"I send a delete request")]
        public void WhenISendADeleteRequest()
        {
            restResponse = SetRestClient().Execute(restRequest);
        }
        
        [Then(@"the post should be deleted")]
        public void ThenThePostShouldBeDeleted()
        {
            Assert.That((restResponse.StatusCode.ToString()), Is.EqualTo("OK"));
        }
        
        [Then(@"the id (.*) should not exists any more")]
        public void ThenTheIdShouldNotExistsAnyMore(int postId)
        {
            restRequest = new RestRequest($"posts/{postId}", Method.POST);
            restResponse = SetRestClient().Execute(restRequest);
        }
    }
}
