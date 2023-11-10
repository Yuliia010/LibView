using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.DAL.Remote.OpenLibraryApiCore.Models
{
    public class Book
    {
        public string? Key { get; set; }
        public string? Title { get; set; }
        public int? EditionCount { get; set; }
        public List<string>? Subjects { get; set; }
        public List<string>? Authors { get; set; }
        public int? FirstPublishYear { get; set; }
        public bool? HasFullText { get; set; }
        public List<string>? Language { get; set; }
        public string? CoverI { get; set; }
        public string? ImageUri { get; set; }

        ////"http://covers.openlibrary.org/b/id/{coverI}-L.jpg"
    }
}
