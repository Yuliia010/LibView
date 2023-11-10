using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.DAL.Remote.OpenLibraryApiCore.Data
{
    public class API_ENGINE : IAPI
    {
        private string BaseUri = "https://openlibrary.org";
        private HttpClient client { set; get; }
        public static int elementsInPage = 6;

        public API_ENGINE()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseUri);
        }
        public string GetPage(int page)
        {
            throw new NotImplementedException();
        }
        //public string GetPageBySubject(string sortSubjStr, int page)
        //{
        //    string addUri= $"/subjects/{sortSubjStr}.json?limit={elementsInPage}&offset={elementsInPage * page}";
        //    var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, BaseUri + addUri));

        //    var content = response.Result.Content.ReadAsStringAsync();
        //    return content.Result.ToString();
        //}
       
        public string GetPageFindByStr(string sortStr, int page)
        {
            string  addUri = $"/search.json?title={sortStr}&work_type=work&limit={elementsInPage}&offset={elementsInPage * (page - 1)}";
            var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, BaseUri + addUri));

            var content = response.Result.Content.ReadAsStringAsync();
            return content.Result.ToString();

           
        }
        public string GetWork(string key)
        {
            var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, BaseUri + $"{key}.json"));

            var content = response.Result.Content.ReadAsStringAsync();
            return content.Result.ToString();
        }
    }
}
