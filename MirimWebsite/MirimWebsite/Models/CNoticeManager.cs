using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

namespace MirimWebsite.Models
{
    public class CNoticeManager
    {
       // private List<CNotice> theNotices;
//        LNoticeDataContext theNoticeContext;
        public int theNPageSize;

        public CNoticeManager(int aNPageSize)
        {
     //       theNotices = new List<CNotice>();
//            theNoticeContext = new LNoticeDataContext();
            theNPageSize = aNPageSize;
        }

        public int GetTotalPage()
        {
            LNoticeDataContext tmpNC = new LNoticeDataContext();
            Table<TNotice> tmpH = tmpNC.TNotice;
            int resNCount;
            resNCount = tmpH.Count();
            return ((resNCount - 1) / theNPageSize + 1);
        }

        public List<CNotice> GetBoard(int aNPage)
        {
            LNoticeDataContext tmpNC = new LNoticeDataContext();

            Table<TNotice> tmpT = tmpNC.TNotice;
            IQueryable<TNotice> tmpQ;
            tmpQ = tmpT;

            IQueryable<TNotice> tmpR = tmpQ.OrderByDescending(x => x.theUniqueID).Skip((aNPage - 1) * theNPageSize).Take(theNPageSize);

            List<TNotice> tmpL = tmpR.ToList<TNotice>();
            List<CNotice> resNList = new List<CNotice>();
            foreach (TNotice iter in tmpL)
            {
                CNotice tmpA = new CNotice();
                tmpA.theUniqueID = iter.theUniqueID;
                tmpA.theNumber = iter.theNumber;
                tmpA.theTitle = iter.theTitle;
                tmpA.theWriter = iter.theWriter;
                tmpA.theContent = iter.theContent;
                tmpA.theDate = iter.theDate;

                if (DateTime.Compare(iter.theDate, DateTime.Today.AddDays(-3)) > 0)
                {
                    tmpA.bNew = 1;
                }
                else
                {
                    tmpA.bNew = 0;
                }
                resNList.Add(tmpA);
            }
            return (resNList);
        }

        public int AddNotice(ref CNotice aNotice)
        {
            LNoticeDataContext tmpNC = new LNoticeDataContext();

        //    CNotice tmpNotice = new CNotice();
         //   tmpNotice.theUniqueID = 0;
            TNotice tmpNotice = new TNotice();
            tmpNotice.theNumber = 0;
            tmpNotice.theTitle = aNotice.theTitle;
            tmpNotice.theContent = aNotice.theContent;
            tmpNotice.theWriter = aNotice.theWriter;
            tmpNotice.theDate = DateTime.Now;
       //     theNotices.Add(tmpNotice);

            tmpNC.TNotice.InsertOnSubmit( tmpNotice );
            tmpNC.SubmitChanges();

            aNotice.theDate = DateTime.Now;
            return (1);
        }

        public void Remove(int aUniqueID)
        {
            LNoticeDataContext tmpNC = new LNoticeDataContext();

            Table<TNotice> Notices = tmpNC.GetTable<TNotice>();
            IQueryable<TNotice> tmpQ = from iter in Notices
                                       where iter.theUniqueID == aUniqueID
                                       select iter;
            TNotice tt = tmpQ.Where(x => x.theUniqueID == aUniqueID).Single();
            Notices.DeleteOnSubmit(tt);
            tmpNC.SubmitChanges();
        }

        public List<CNotice> GetMainNotices()
        {
            LNoticeDataContext tmpNC = new LNoticeDataContext();

            //  return (theNotices);
            IQueryable<TNotice> tmpR = tmpNC.TNotice.OrderByDescending( x => x.theUniqueID ).Take( 5 );


            List<TNotice> tmpL = tmpR.ToList<TNotice>();
            List<CNotice> resNotices = new List<CNotice>();
            foreach (TNotice iter in tmpL)
            {
                CNotice tmpNotice = new CNotice();
                tmpNotice.theUniqueID = iter.theUniqueID;
                tmpNotice.theNumber = iter.theNumber;
                tmpNotice.theTitle = iter.theTitle;
                tmpNotice.theWriter = iter.theWriter;
                tmpNotice.theContent = iter.theContent;
                tmpNotice.theDate = iter.theDate;
                resNotices.Add(tmpNotice);

            }
            return (resNotices);

        }
        public List<CNotice> GetNotices()
        {
            LNoticeDataContext tmpNC = new LNoticeDataContext();

          //  return (theNotices);
            IQueryable<TNotice> tmpR = tmpNC.TNotice.OrderByDescending( x => x.theUniqueID );


            List<TNotice> tmpL = tmpR.ToList<TNotice>();
            List<CNotice> resNotices = new List<CNotice>();
            foreach (TNotice iter in tmpL)
            {
                CNotice tmpNotice = new CNotice();
                tmpNotice.theUniqueID = iter.theUniqueID;
                tmpNotice.theNumber = iter.theNumber;
                tmpNotice.theTitle = iter.theTitle;
                tmpNotice.theWriter = iter.theWriter;
                tmpNotice.theContent = iter.theContent;
                tmpNotice.theDate = iter.theDate;
                resNotices.Add(tmpNotice);
            }
            return (resNotices);

        }

        
        
    }
}