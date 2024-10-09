using makemelaughCore.Requests;
using makemelaughCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace makemelaughAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakeMeLaughController : ControllerBase
    {    

        private MakeMeLaughServiceContract _makeMeLaughService;
        private IConfigurationRoot _envConfiguration;
        public MakeMeLaughController(MakeMeLaughServiceContract makeMeLaughServoce)
        {
            // #degreed
            // Dependency Injection, injecting the dependency.
            this._makeMeLaughService = makeMeLaughServoce;

            // #degreed
            // re-building the configuration, to load any change in url or configuration at each request.
            // this will help us load any change in appsetting at runtime, without un-mounting the service.
            _envConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();         

        }

        /// <summary>
        /// This Api is the endpoint to get the randome joke
        /// </summary>
        /// <param name="trueForPlainText_falseForJson">This decides the output type for the response. PlainText or Json</param>
        /// <returns></returns>
        [HttpGet("GetRandomJoke")]
        
        public IActionResult GetRandomJoke(bool trueForPlainText_falseForJson = true)
        {
            try
            {
                var baseUrl = _envConfiguration.GetValue<string>("externalServiceBaseUrl");
                var endPoint = _envConfiguration.GetValue<string>("externalRandomJokeEndpoint");
                var outputEnum = trueForPlainText_falseForJson ? OutputTypeEnum.PlainText : OutputTypeEnum.Json;
                var randomJokeRequet = new RandomJokeRequest(baseUrl, endPoint, outputEnum);

                // #degreed invoking the external service through DI
                var res = this._makeMeLaughService.GetRandomJoke(randomJokeRequet);
                return Ok(res.Result.responseAsString);
            }
            catch (Exception ex)
            {
                //#degreed 
                // Abstracting the exception, to hide the actual message/ stack trace for outside world.
                var message = "Error occured during fetchig results. Please check the logs.";
                Log.Error(ex, ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
               
            }
        }


        /// <summary>
        /// Gets the jokes matching an input pattern
        /// </summary>
        /// <param name="searchPattern">filter value to fetch the jokes on the basis of this.</param>
        /// <param name="trueForPlainText_falseForJson">This decides the output type for the response. PlainText or Json</param>
        /// <returns></returns>
        [HttpGet("searchJokeByPattern")]
       
        public IActionResult GetJokesBySearchPattern(string searchPattern, bool trueForPlainText_falseForJson = true)
        {
            try
            {
                var baseUrl = _envConfiguration.GetValue<string>("externalServiceBaseUrl");
                var endPoint = _envConfiguration.GetValue<string>("externalJokeSearchEndpoint");                
                var outputEnum = trueForPlainText_falseForJson ? OutputTypeEnum.PlainText : OutputTypeEnum.Json;
                var jokePatternRequest = new JokePatternRequest(baseUrl, endPoint, outputEnum);
                jokePatternRequest.searchPattern = searchPattern;
                var res = this._makeMeLaughService.GetJokeByPattern(jokePatternRequest);
                return Ok(res.Result.fetchResponse(outputEnum));
            }
            catch (Exception ex)
            {
                //#degreed 
                // Abstracting the exception, to hide the actual message/ stack trace for outside world.
                var message = "Error occured during fetchig results. Please check the logs.";
                Log.Error(ex, ex.Message);              

                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }
        }


    }
}
