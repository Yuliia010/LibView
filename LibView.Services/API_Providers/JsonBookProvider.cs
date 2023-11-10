using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibView.DAL.Remote.OpenLibraryApiCore.Data;
using LibView.DAL.Remote.OpenLibraryApiCore.Models;

namespace LibView.Domain.API_Providers
{
    internal class JsonBookProvider
    {
        public static int MaxPagesInJson(string json)
        {
            JObject keyValuePairs = JObject.Parse(json);
            JToken info = keyValuePairs["numFound"];

            int docsFound = int.Parse(info.ToString());
            int maxPages = docsFound / API_ENGINE.elementsInPage;

            return maxPages;
        }
        public static BookInfo FromJsonToBookInfo(string json)
        {
            
            JObject keyValuePairs = JObject.Parse(json);
            BookInfo item = new BookInfo();
            item.Key = keyValuePairs.Value<string>("key");
            item.Title = keyValuePairs.Value<string>("title");
            try
            {
                item.Description = keyValuePairs.Value<string>("description");
            }catch (Exception ex)
            {
                item.Description = "There is no description";
            }
            
                
            return item;
        }
        public static List<Book> FromJsonToBooksList(string json)
        {
           
            List<Book> characters = new List<Book>();
            JObject keyValuePairs = JObject.Parse(json);
            IList<JToken> results = keyValuePairs["docs"].Children().ToList();

            foreach (JToken token in results)
            {
                Book item = new Book();
                item.Key = token.Value<string>("key");
                item.Title = token.Value<string>("title");
                item.Subjects = token["subject"]?.Values<string>().ToList() ?? new List<string>();
                item.Authors = token["author_name"]?.Values<string>().ToList() ?? new List<string>();
                item.HasFullText = token.Value<bool>("has_fulltext");
                item.FirstPublishYear = token.Value<int>("first_publish_year");
                item.CoverI = token.Value<string>("cover_i");
                item.Language = token["language"]?.Values<string>().ToList() ?? new List<string>();
                item.ImageUri = $"http://covers.openlibrary.org/b/id/{item.CoverI}-L.jpg";
                characters.Add(item);
            }
            return characters;
        }
    }
}
