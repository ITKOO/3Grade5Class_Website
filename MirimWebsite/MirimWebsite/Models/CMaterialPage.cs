using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MirimWebsite.Models
{
    public class CMaterialPage
    {
        public List<CMaterials> theItems { get; set; }
        public CMaterials theCurrentItem { get; set; }
        public int bModifyItem { get; set; }
        public int bAnswerItem { get; set; }
        public int theParentID { get; set; }
        public bool bDeleteItem { get; set; }

        public int theTotalPage;
        public int theCurrentPage;
    }
}