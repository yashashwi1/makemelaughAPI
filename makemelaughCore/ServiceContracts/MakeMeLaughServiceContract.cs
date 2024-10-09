using makemelaughCore.Requests;
using makemelaughCore.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.ServiceContracts
{
    /// <summary>
    /// This is an interface a contract for the outside world.
    /// In future if new apis are coming we can either extend this or create similar interfaces matching Interface seggregation principle of SOLID
    /// </summary>
    public interface MakeMeLaughServiceContract
    {

        Task<RandomJokeResponse> GetRandomJoke(RandomJokeRequest request);

        Task<JokePatternResponse> GetJokeByPattern(JokePatternRequest request);
       
    }
}
