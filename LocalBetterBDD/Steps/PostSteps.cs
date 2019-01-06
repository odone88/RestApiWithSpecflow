using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LocalBetterBDD
{
    abstract public class PostSteps
    {
        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
        public IRestResponse restResponse { get; set; }
        public JsonDeserializer deserializer { get; set; }

        public RestClient SetRestClient()
        {
            restClient = new RestClient(ConfigurationManager.AppSettings["baseUrl"]);
            return restClient;
        }

    }
}
