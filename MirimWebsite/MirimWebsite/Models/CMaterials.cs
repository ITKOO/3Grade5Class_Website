using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MirimWebsite.Models
{
    public class CMaterials
    {
        public int theUniqueID { get; set; }

        public int theNumber { get; set; }

        public string theTitle { get; set; }

        public string theWriter { get; set; }

        public string theAttachFile { get; set; }
        public string theFileName { get; set; }

        public HttpPostedFileBase theFile { get; set; }

        public DateTime theDate { get; set; }

        public int bNew { get; set; }
    }
}