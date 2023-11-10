using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.DAL.Remote.OpenLibraryApiCore.Data
{
    public interface IAPI
    {
        public string GetPage(int page);
        
    }
}
