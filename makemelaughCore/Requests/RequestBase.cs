using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Requests
{
    /// <summary>
    /// This the parent for Requests.
    /// This class gives a bare minimum template for each requests to inherit.
    /// </summary>
    public class RequestBase
    {
        /// <summary>
        /// Field for having base url made readonly intentionally to avoid, multiple update
        /// </summary>
        private readonly string _baseUrl;

        protected string _endPoint;

        protected RestRequest _request;

        private readonly OutputTypeEnum _outputType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="type"></param>
        public RequestBase(string baseUrl, OutputTypeEnum type) 
        {
            _baseUrl = baseUrl;           
            _outputType = type;
        }

        public string GetBaseUrl
        {
            get { return _baseUrl; }
        }

        public string GetEndpoint
        {
            get { return _endPoint; }
        }

        public OutputTypeEnum OutputType
        {
            get { return _outputType; }
        }
       internal RestRequest getPreparedRequest
        {
            get { return _request; }
        }

        /// <summary>
        /// This is made deliberately internal as this should not be invocable from outside.
        /// This is responsibility of MakeMeLaughService
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        internal virtual void prepareRequest(Method method = Method.Get)
        {
            var request = new RestRequest(string.Empty, method);
            switch (_outputType)
            {
                case OutputTypeEnum.PlainText:
                default:
                    {
                        request.AddHeader("Accept", "text/plain");
                        break;
                    }
                case OutputTypeEnum.Json: {
                        request.AddHeader("Accept", "application/json"); 
                        break;
                    }
            }

            _request = request;
           
        }

    }
}
