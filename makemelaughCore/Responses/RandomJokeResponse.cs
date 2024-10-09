using makemelaughCore.Models;
using makemelaughCore.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace makemelaughCore.Responses
{
    public class RandomJokeResponse:ResponseBase
    {
        internal Joke Joke { get; set; }
    }
}
