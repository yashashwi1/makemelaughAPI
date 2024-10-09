using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Models
{
    /// <summary>
    /// This is the model for search api of external service.
    /// This is deliberately made internal, as the outside assembly should not care about this model.
    /// This model is only important to handle response from external service,
    /// </summary>
    internal class SearchJokeModel
    {
        public string current_page { get; set; }
        public int limit { get; set; }
        public string next_page { get; set; }
        public string previous_page { get; set; }

        public Joke[] results{ get; set; }
    }
}
