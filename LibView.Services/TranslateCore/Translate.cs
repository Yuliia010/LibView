using LibView.DAL.Remote.OpenLibraryApiCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.Domain.TranslateCore
{
    public class Translate
    {
        private static readonly string key = "8f3ef20172d440b3959d4130a991ea9b";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";

        // location, also known as region.
        // required if you're using a multi-service or regional (not global) resource. It can be found in the Azure portal on the Keys and Endpoint page.
        private static readonly string location = "westeurope";

        public static async Task<string> GetTranslate(string textToTranslate)
        {
            string route = "/translate?api-version=3.0&from=en&to=uk&includeAlignment=true";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string resultJson = await response.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(resultJson);
                JObject translationObject = (JObject)jsonArray[0]["translations"][0];
                string translatedText = translationObject["text"].ToString();

                return translatedText;
            }
        }

    }
}
