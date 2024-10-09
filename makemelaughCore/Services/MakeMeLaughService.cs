using makemelaughCore.Requests;
using makemelaughCore.Responses;
using makemelaughCore.ServiceContracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Services
{
    /// <summary>
    /// Implementation for interface.
    /// </summary>
    internal class MakeMeLaughService:MakeMeLaughServiceContract
    {       
        /// <summary>
        /// Service to fetch random jokes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RandomJokeResponse> GetRandomJoke(RandomJokeRequest request)
        {

            request.prepareRequest();
            var response = await Task.Run(()=>this.ExecuteWebRequest(request));
            var randomJokeResponse = new RandomJokeResponse();           
            randomJokeResponse.StatusCode = response.StatusCode;
            randomJokeResponse.errorMessage = response.ErrorMessage;
            randomJokeResponse.responseAsString = response.Content;
            return randomJokeResponse;
        }

        /// <summary>
        /// Service to fetch jokes by patten
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JokePatternResponse> GetJokeByPattern(JokePatternRequest request)
        {
            request.prepareRequest();
            var response = await Task.Run(() => this.ExecuteWebRequest(request));
            var jokePatternResponse = new JokePatternResponse(response);
          
            return jokePatternResponse;          
        }
                
        /// <summary>
        /// Http Call service, this is generic across.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private RestResponse ExecuteWebRequest(RequestBase request)
        {
            try
            {
                var client = new RestClient(request.GetBaseUrl + request.GetEndpoint);
                var response = client.Execute(request.getPreparedRequest);
                return response;
            }
           catch(Exception ex)
            {
              throw ex;
            }           
        }
    }
}
