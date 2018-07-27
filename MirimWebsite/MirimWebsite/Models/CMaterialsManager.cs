using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

namespace MirimWebsite.Models
{
    public class CMaterialsManager
    {
        // private List<CMaterials> theMaterials;
//        LMaterialsDataContext theMaterialsContext;
        public int thePageSize;

        public CMaterialsManager( int aPageSize )
        {
            //       theMaterials = new List<CMaterials>();
//            theMaterialsContext = new LMaterialsDataContext();
            thePageSize = aPageSize;
        }

        public int GetTotalPage()
        {
            LMaterialsDataContext tmpMC = new LMaterialsDataContext();
            Table<TStudy> tmpH = tmpMC.TStudy;
            int resCount;
            resCount = tmpH.Count();
            return ( ( resCount - 1 ) / thePageSize + 1 );
        }

        public List<CMaterials> GetBoard( int aPage )
        {
            LMaterialsDataContext tmpMC = new LMaterialsDataContext();
            Table<TStudy> tmpT = tmpMC.TStudy;
            IQueryable<TStudy> tmpQ;
            tmpQ = tmpT;

            IQueryable<TStudy> tmpR = tmpQ.OrderByDescending( x => x.theUniqueID ).Skip( ( aPage - 1 ) * thePageSize ).Take( thePageSize );

            List<TStudy> tmpL = tmpR.ToList<TStudy>();
            List<CMaterials> resList = new List<CMaterials>();
            foreach( TStudy iter in tmpL )
            {
                CMaterials tmpA = new CMaterials();
                tmpA.theUniqueID = iter.theUniqueID;
                tmpA.theNumber = iter.theNumber;
                tmpA.theTitle = iter.theTitle;
                tmpA.theWriter = iter.theWriter;
                tmpA.theAttachFile = iter.theAttachFile;
                tmpA.theFileName = iter.theFileName;
                tmpA.theDate = iter.theDate;

                if( DateTime.Compare( iter.theDate, DateTime.Today.AddDays( -3 ) ) > 0 )
                {
                    tmpA.bNew = 1;
                }
                else
                {
                    tmpA.bNew = 0;
                }
                resList.Add( tmpA );
            }
            return ( resList );
        }

        public int AddMaterials(ref CMaterials aMaterials)
        {
            LMaterialsDataContext tmpMC = new LMaterialsDataContext();

            TStudy tmpMaterials = new TStudy();
            tmpMaterials.theNumber = 0;
            tmpMaterials.theTitle = aMaterials.theTitle;
            tmpMaterials.theAttachFile = aMaterials.theAttachFile;
            //tmpMaterials.theAttachFile = "abc.hwp";
            // tmpMaterials.theAttachFile = Request.Form["materials"];
            //tmpMaterials.theFileName = aMaterials.theFile;
            //tmpMaterials.theFileName = "123.jpg";
            tmpMaterials.theWriter = aMaterials.theWriter;
            tmpMaterials.theDate = DateTime.Now;
            tmpMaterials.theFileName = aMaterials.theFileName;
            //     theNotices.Add(tmpNotice);

            tmpMC.TStudy.InsertOnSubmit( tmpMaterials );
            tmpMC.SubmitChanges();

            aMaterials.theDate = DateTime.Now;
            return (1);
        }

        public void MRemove(int mUniqueID)
        {
            LMaterialsDataContext tmpMC = new LMaterialsDataContext();

            Table<TStudy> Materials = tmpMC.GetTable<TStudy>();
            IQueryable<TStudy> tmpQ = from iter in Materials
                                       where iter.theUniqueID == mUniqueID
                                       select iter;
            TStudy tt = tmpQ.Where(x => x.theUniqueID == mUniqueID).Single();
            Materials.DeleteOnSubmit(tt);
            tmpMC.SubmitChanges();
        }

        public List<CMaterials> GetMaterials()
        {
            LMaterialsDataContext tmpMC = new LMaterialsDataContext();

            //  return (theNotices);
            IQueryable<TStudy> tmpR = tmpMC.TStudy.OrderByDescending( x => x.theUniqueID );

//            int i = 0;
            List<TStudy> tmpL = tmpR.ToList<TStudy>();
            List<CMaterials> resMaterials = new List<CMaterials>();

            foreach (TStudy iter in tmpL)
            {
                CMaterials tmpMaterials = new CMaterials();
                tmpMaterials.theUniqueID = iter.theUniqueID;
                tmpMaterials.theNumber = iter.theNumber;
                tmpMaterials.theTitle = iter.theTitle;
                tmpMaterials.theWriter = iter.theWriter;
                tmpMaterials.theAttachFile = iter.theAttachFile;
                tmpMaterials.theDate = iter.theDate;
                tmpMaterials.theFileName = iter.theFileName;
                resMaterials.Add(tmpMaterials);
/*                if (i > 0)
                {
                    break;
                }
                i++;
*/            }
            return (resMaterials);

        }
    }
}