using Azure;
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
    public class BookInfoUseCase
    {
        private static API_ENGINE engine = new API_ENGINE();
        public static BookInfo GetBookInfo(Book book)
        {
            var workResult = engine.GetWork(book.Key);
            BookInfo bookInfo = JsonBookProvider.FromJsonToBookInfo(workResult);
            bookInfo.Authors = book.Authors;
            bookInfo.ImageUri = book.ImageUri;
            bookInfo.FirstPublishYear = book.FirstPublishYear;
            bookInfo.HasFullText = book.HasFullText;
            bookInfo.Subjects = book.Subjects;
            bookInfo.Language = book.Language;

            return bookInfo;
        }
    }
}
