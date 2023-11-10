using LibView.DAL.Remote.OpenLibraryApiCore.Data;
using LibView.DAL.Remote.OpenLibraryApiCore.Models;
using LibView.Domain.API_Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.Domain.UseCases
{
    public class JsonBookUseCase
    {
        private int page = 1;
        private int maxPages;
        private string _searchSTR;
        private API_ENGINE engine;
        private List<Book> books { get; set; }

        public JsonBookUseCase(string searchStr)
        {
            engine = new API_ENGINE();
            _searchSTR = searchStr.ToLower().Replace(" ", "+");
            
           
        }
        public List<Book> GetPage(int page)
        {
           var pageResult = engine.GetPageFindByStr(_searchSTR, page);
            books = JsonBookProvider.FromJsonToBooksList(pageResult);
            maxPages = JsonBookProvider.MaxPagesInJson(pageResult);
            return books;
        }
        public int GetMaxPages()
        {
            return maxPages;
        }

        
    }
}
