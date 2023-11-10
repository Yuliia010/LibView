using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.DAL.Remote.OpenLibraryApiCore.Models
{
    public class BookInfo
    {
        public string? Key { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Subjects { get; set; }
        public List<string>? Authors { get; set; }
        public int? FirstPublishYear { get; set; }
        public bool? HasFullText { get; set; }
        public List<string>? Language { get; set; }
        public string? ImageUri { get; set; }

       
    }
}
