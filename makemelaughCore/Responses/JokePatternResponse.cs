using makemelaughCore.Models;
using makemelaughCore.Requests;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace makemelaughCore.Responses
{
    /// <summary>
    /// Response for search pattern api.
    /// </summary>
    public class JokePatternResponse:ResponseBase
    {
        /// <summary>
        /// This enum is used to group the response based on content length.
        /// </summary>
        private enum JokeSizeEnum
        {
            Short = 10, // 10 is the length value
            Medium = 20, 
            Long = 30
        }

        private SearchJokeModel Jokes { get; set; }

        public JokePatternResponse(RestResponse response)
        {
            this.StatusCode = response.StatusCode;
            this.errorMessage = response.ErrorMessage;
            if (this.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.responseAsString = response.Content;
            }
        }

        /// <summary>
        /// This will prepare the response finally for consumption
        /// </summary>
        /// <param name="outputType"></param>
        /// <returns></returns>
        public string fetchResponse(OutputTypeEnum outputType)
        {
            if( outputType == OutputTypeEnum.Json)
            { 
                this.Jokes = JsonConvert.DeserializeObject<SearchJokeModel>(this.responseAsString);
                if (this.Jokes == null)
                {
                    return "";
                }

                Dictionary<string, List<Joke>> jokesGroupedByLength = new Dictionary<string, List<Joke>>();
                this.Jokes.results.ToList().ForEach(joke =>
                        {
                            this.groupJokesByLength(joke, jokesGroupedByLength);
                        });

                
                return JsonConvert.SerializeObject(jokesGroupedByLength);
               
            }
            return this.responseAsString;
        }


        /// <summary>
        /// Internal logic to club items based on the content length
        /// </summary>
        /// <param name="joke"></param>
        /// <param name="jokesGroupedByLength"></param>
        private void groupJokesByLength(Joke joke, Dictionary<string, List<Joke>> jokesGroupedByLength)
        {
            if(joke.joke.Count() <= (int)JokeSizeEnum.Short)
            {
                var shortKey = JokeSizeEnum.Short.ToString();
                this.fillDictionary(jokesGroupedByLength, shortKey, joke);
            }

            if (joke.joke.Count() > (int)JokeSizeEnum.Short && joke.joke.Count() <= (int)JokeSizeEnum.Medium)
            {
                var mediumKey = JokeSizeEnum.Medium.ToString();
                this.fillDictionary(jokesGroupedByLength, mediumKey, joke);
            }

            if (joke.joke.Count() >= (int)JokeSizeEnum.Long)
            {
                var longKey = JokeSizeEnum.Long.ToString();
                this.fillDictionary(jokesGroupedByLength, longKey, joke);
            }
            
        }

        /// <summary>
        /// Filling dictionary based on key and value, where key is content length and value are jokes.
        /// </summary>
        /// <param name="groupedDictionary"></param>
        /// <param name="sizeKey"></param>
        /// <param name="joke"></param>
        private void fillDictionary(Dictionary<string, List<Joke>> groupedDictionary, string sizeKey, Joke joke)
        {
            if (groupedDictionary.ContainsKey(sizeKey))
            {
                var jokes = groupedDictionary[sizeKey];
                jokes.Add(joke);
            }
            else
            {
                groupedDictionary.Add(sizeKey, new List<Joke>() { joke });
            }
        }

    }
}
