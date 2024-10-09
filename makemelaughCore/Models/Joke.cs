using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Models
{
    /// <summary>
    /// This is the model for Joke when returned as response from external service.
    /// This is deliberately made internal, as the outside assembly should not care about this model.
    /// This model is only important to handle response from external service,
    /// </summary>
    internal class Joke
    {
        public string id { get; set; }

        public string joke { get; set; }

    }
}
