using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Web.Mvc;

namespace MirimWebsite.Models
{
    public static class CHelpers
    {
        public static MvcHtmlString PageLinks( this HtmlHelper html, int aCurrentPage, int aTotalPage, Func<int, string> pageUrl )
        {
            int i = 0;
            StringBuilder result = new StringBuilder();
            for( i = 0; i < aTotalPage; i++ )
            {
                TagBuilder tag;
                if( i + 1 == aCurrentPage )
                {
                    tag = new TagBuilder( "strong" );
                }
                else
                {
                    tag = new TagBuilder( "a" );
                    tag.MergeAttribute( "href", pageUrl( i + 1 ) );
                    //                    tag.AddCssClass()
                }
                tag.InnerHtml = ( i + 1 ).ToString();
                result.Append( tag.ToString() );
            }
            return ( MvcHtmlString.Create( result.ToString() ) );
        }
    }
}