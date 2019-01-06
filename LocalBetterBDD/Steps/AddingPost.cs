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
    public class AddingPost : PostSteps
    {


        [Given(@"I have post endpoint ready with post id (.*)")]
        public void GivenIHavePostEndpointReadyWithPostId(int postId)
        {

            restRequest = new RestRequest("posts", Method.POST);
            var post = new Post
            {
                id = postId,
                title = "blabla",
                author = "author Idontwant"
            };

            restRequest.AddJsonBody(post);     
        }
        
        [When(@"I send a post request")]
        public void WhenISendAPostRequest()
        {
            restResponse = SetRestClient().Execute(restRequest);
        }
        
        [Then(@"the post should be added and id (.*) the same as sent")]
        public void ThenThePostShouldBeAddedAndIdTheSameAsSent(int addedId)
        {
            deserializer = new JsonDeserializer();
            var output = deserializer.Deserialize<Dictionary<string, string>>(restResponse);
            Assert.That(output["id"].ToString(), Is.EqualTo(addedId.ToString()));
        }
    }
}
