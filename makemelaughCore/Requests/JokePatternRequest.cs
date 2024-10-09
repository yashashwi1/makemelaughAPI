using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Requests
{
    /// <summary>
    /// Request to handle search criteria for the joke.
    /// Made public intentionally to allow outside world to consume this api.
    /// </summary>
    public class JokePatternRequest:RequestBase
    {
        public JokePatternRequest(string baseUrl, string endPoint, OutputTypeEnum type) : 
            base(baseUrl, type)
        { 
            this._endPoint = endPoint;
        }

        public string searchPattern {  get; set; }

        /// <summary>
        /// This is made deliberately internal as this should not be invocable from outside.
        /// Overriding parent implementation
        /// This is responsibility of MakeMeLaughService
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        internal override void prepareRequest(Method method = Method.Get)
        {
            var request = new RestRequest(string.Empty, method);
            this._endPoint = this._endPoint + this.searchPattern;
            switch (this.OutputType)
            {
                case OutputTypeEnum.PlainText:
                default:
                    {
                        request.AddHeader("Accept", "text/plain");
                        break;
                    }
                case OutputTypeEnum.Json:
                    {
                        request.AddHeader("Accept", "application/json");
                        break;
                    }
            }
           
            _request = request;
        }

       
    }
}
