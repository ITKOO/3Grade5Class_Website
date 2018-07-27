using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MirimWebsite.Models
{
    public class CInstance
    {
        public static CNoticeManager theNoticeManager;
        public static CMaterialsManager theMaterialsMananger;
        public static int bInit = 0;

        public static void Initialize()
        {
            if (bInit == 0)
            {
                theNoticeManager = new CNoticeManager( 3 );
                theMaterialsMananger = new CMaterialsManager( 3 );
            }
            bInit = 1;
        }
    }
}