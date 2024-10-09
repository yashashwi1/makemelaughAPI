using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Requests
{
    /// <summary>
    /// Request to handle random jokes.
    /// Made public intentionally to allow outside world to consume this api.
    /// </summary>
    public class RandomJokeRequest:RequestBase
    {
        
        public RandomJokeRequest(string baseUrl, string endPoint, OutputTypeEnum type):base(baseUrl, type) 
        {
            this._endPoint = endPoint;            
        }
    }
}
