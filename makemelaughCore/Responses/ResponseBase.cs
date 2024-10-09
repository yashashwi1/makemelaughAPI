using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Responses
{
    public class ResponseBase:RestResponse
    {       
        public string errorMessage;

        public string responseAsString;
    }
}
