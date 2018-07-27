using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MirimWebsite.Models;


namespace MirimWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            List<String> tmpStrs = new List<string>();
            //월
            tmpStrs.Add("영 어 (윤성웅T) ");
            tmpStrs.Add("국 어 (이대형T) ");
            tmpStrs.Add("NCP (정우진T) ");
            tmpStrs.Add("NCP (정우진T) ");
            tmpStrs.Add("DBP (이형섭T)");
            tmpStrs.Add("DBP (이형섭T)");
            tmpStrs.Add("체 육 (고낙은T) ");
            //화
            tmpStrs.Add("WPG (함기훈T) ");
            tmpStrs.Add("창 체 (이정임T) ");
            tmpStrs.Add("WSM (윤선희T) ");
            tmpStrs.Add("WSM (윤선희T) ");
            tmpStrs.Add("NCP (정우진T)");
            tmpStrs.Add("NCP (정우진T)");
            tmpStrs.Add("영 어 (윤성웅T) ");
            //수
            tmpStrs.Add("WPG (최규정T) ");
            tmpStrs.Add("WPG (최규정T) ");
            tmpStrs.Add("NMT (백현정T) ");
            tmpStrs.Add("NMT (백현정T) ");
            tmpStrs.Add("DBP (박지우T)");
            tmpStrs.Add("동아리/자치활동");
            tmpStrs.Add("동아리/멘토링 ");
            //목
            tmpStrs.Add("정보보호 (권오재T) ");
            tmpStrs.Add("정보보호 (권오재T) ");
            tmpStrs.Add("국 어 (최영진T) ");
            tmpStrs.Add("영 어 (윤성웅T) ");
            tmpStrs.Add("WPG (최규정T)");
            tmpStrs.Add("NMT (백현정T)");
            tmpStrs.Add("NMT (백현정T) ");
            //금
            tmpStrs.Add("DBP (박지우T) ");
            tmpStrs.Add("DBP (박지우T) ");
            tmpStrs.Add("WSM (윤선희T) ");
            tmpStrs.Add("WSM (윤선희T) ");
            tmpStrs.Add("영 어 (윤성웅T)");
            tmpStrs.Add("정보보호 (권오재T)");
            tmpStrs.Add("창 제 (이종태T) ");

            DateTime tmpDT = DateTime.Now;
            ViewBag.theNotice = CInstance.theNoticeManager.GetMainNotices();
            int tmpWeek = (int)tmpDT.DayOfWeek;
            if (1 <= tmpWeek && tmpWeek <= 5 )
            {
                ViewBag.theTimeTable = tmpStrs.Skip((tmpWeek - 1) * 7).Take(7);
            }
            else
            {
                List<string> tmpNone = new List<string>();
                tmpNone.Add( "수업없음");
                ViewBag.theTimeTable = tmpNone;
            }
            return View();
        }


        public ActionResult Gallery()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(@"~/images/"));
            int count = 0;
            if (dir.GetFiles() != null)
            {
                count = dir.GetFiles().Length;
            }

            List<String> tmpList = new List<string>();

            foreach (var item in dir.GetFiles())
            {
                tmpList.Add(  item.Name );
//                // 파일 이름 출력
//                stringArray[j] = item.Name;
//                System.Diagnostics.Trace.WriteLine("FILE NAME : " + item.Name);
//                j++;
            }
/*
            string[] stringArray = new string[count];
            var j = 0;

            foreach (var item in di.GetFiles())
            {
                // 파일 이름 출력
                stringArray[j] = item.Name;
                System.Diagnostics.Trace.WriteLine("FILE NAME : " + item.Name);
                j++;
            }

            var imagePath = "";
            imagePath = @"~/images/";
*/
            ViewBag.theImages = tmpList;
            return View();
        }

        [HttpPost]
        public ActionResult Gallery(HttpPostedFileBase file)
        {

            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(@"~/images/"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Gallery");
        }

        public ActionResult GalleryWrite()
        {
            return View();
        }
        public int[] number;
        public ActionResult Seat()
        {
            string[] str = new string[] { "강혜수", "구지원", "김두리", "김민경", "김서윤", "김진민", "김효원", "박가연", "오서연", "유시은", "이경민", "이새봄", "이예림", "이유리", "이예본", "장유진", "최민경", "최혜림", "홍하은" };
           
            Random rand = new Random();

            number = new int[20];
            int i;
            int[] tempNum = new int[20];
            for (i = 0; i < 19; i++)
            {
                tempNum[i] = i + 1;
            }
            for (i = 0; i < 19; i++)
            {
                int iNum1 = rand.Next(0, 19);
                int iNum2 = rand.Next(0, 19);
                int temp = tempNum[iNum1];
                tempNum[iNum1] = tempNum[iNum2];
                tempNum[iNum2] = temp;
            }
            ViewBag.Name1 = str[tempNum[0] - 1]; ViewBag.Name2 = str[tempNum[1] - 1]; ViewBag.Name3 = str[tempNum[2] - 1]; ViewBag.Name4 = str[tempNum[3] - 1]; ViewBag.Name5 = str[tempNum[4] - 1];
            ViewBag.Name6 = str[tempNum[5] - 1]; ViewBag.Name7 = str[tempNum[6] - 1]; ViewBag.Name8 = str[tempNum[7] - 1]; ViewBag.Name9 = str[tempNum[8] - 1]; ViewBag.Name10 = str[tempNum[9] - 1];
            ViewBag.Name11 = str[tempNum[10] - 1]; ViewBag.Name12 = str[tempNum[11] - 1]; ViewBag.Name13 = str[tempNum[12] - 1]; ViewBag.Name14 = str[tempNum[13] - 1]; ViewBag.Name15 = str[tempNum[14] - 1];
            ViewBag.Name16 = str[tempNum[15] - 1]; ViewBag.Name17 = str[tempNum[16] - 1]; ViewBag.Name18 = str[tempNum[17] - 1]; ViewBag.Name19 = str[tempNum[18] - 1];


            number = new int[20];
            int[] tempNum2 = new int[20];
            for (i = 0; i < 19; i++)
            {
                tempNum2[i] = i + 1;
            }
            for (i = 0; i < 19; i++)
            {
                int iNum1 = rand.Next(0, 19);
                int iNum2 = rand.Next(0, 19);
                int temp = tempNum2[iNum1];
                tempNum2[iNum1] = tempNum2[iNum2];
                tempNum2[iNum2] = temp;
            }

            string[] str2 = new string[] { "교실 쓸기", "교실 쓸기", "교실 쓸기", "교실 쓸기", "운동장쪽 유리(앞)", "운동장쪽 유리(뒤)", "교실 대걸레", "교실 대걸레", "복도쪽 유리(앞)", "복도쪽 유리(뒤)", "쓰레기통, 청소함", "쓰레기통, 청소함", "복도 쓸기", "창틀, 사물함, 칠판", "복도 대걸레", "개수실", "개수실 앞 복도 쓸기", "개수실 앞 복도 대걸레", "아트스튜디오 복도 쓸기", "아트스튜디오 복도 대걸레", "아트스튜디오 복도 대걸레" };


            ViewBag.Clean1 = str2[tempNum2[0] - 1]; ViewBag.Clean2 = str2[tempNum2[1] - 1]; ViewBag.Clean3 = str2[tempNum2[2] - 1]; ViewBag.Clean4 = str2[tempNum2[3] - 1]; ViewBag.Clean5 = str2[tempNum2[4] - 1];
            ViewBag.Clean6 = str2[tempNum2[5] - 1]; ViewBag.Clean7 = str2[tempNum2[6] - 1]; ViewBag.Clean8 = str2[tempNum2[7] - 1]; ViewBag.Clean9 = str2[tempNum2[8] - 1]; ViewBag.Clean10 = str2[tempNum2[9] - 1];
            ViewBag.Clean11 = str2[tempNum2[10] - 1]; ViewBag.Clean12 = str2[tempNum2[11] - 1]; ViewBag.Clean13 = str2[tempNum2[12] - 1]; ViewBag.Clean14 = str2[tempNum2[13] - 1]; ViewBag.Clean15 = str2[tempNum2[14] - 1];
            ViewBag.Clean16 = str2[tempNum2[15] - 1]; ViewBag.Clean17 = str2[tempNum2[16] - 1]; ViewBag.Clean18 = str2[tempNum2[17] - 1]; ViewBag.Clean19 = str2[tempNum2[18] - 1];



            return View();
        }

        public ActionResult Exam()
        {
            return View();
        }

        public ActionResult MenuBar()
        {
            return View();
        }

        public ActionResult Footer()
        {
            return View();
        }



        public ActionResult Notice()
        {
            ViewBag.theCurrentPage = 1;
            ViewBag.theTotalPage = CInstance.theNoticeManager.GetTotalPage();
            ViewBag.theNotice = CInstance.theNoticeManager.GetBoard(1);
            return View();
        }
        [HttpGet]
        public ActionResult Notice(int page = 1)
        {
            ViewBag.theCurrentPage = page;
            ViewBag.theTotalPage = CInstance.theNoticeManager.GetTotalPage();
            ViewBag.theNotice = CInstance.theNoticeManager.GetBoard(page);
            return (View());
        }
        [HttpPost]
        public ActionResult Notice(CNotice aNotice)
        {
            int tmpBool;
            tmpBool = CInstance.theNoticeManager.AddNotice(ref aNotice);
            if (tmpBool == 1)
            {
                return (RedirectToAction("Notice"));
            }

            return (View(aNotice));
        }
        public ActionResult NoticeOK(CNotice aNotice)
        {
            ViewBag.theWriter = aNotice.theWriter;
            ViewBag.theTitle = aNotice.theTitle;
            ViewBag.theContent = aNotice.theContent;
            ViewBag.theDate = aNotice.theDate.ToString("yyyy.MM.dd");
            return View(aNotice);
        }
        public ActionResult NoticeDelete(int uid)
        {
            CInstance.theNoticeManager.Remove(uid);
            return RedirectToAction("Notice");
        }

        public ActionResult Materials()
        {
            ViewBag.theCurrentPage = 1;
            ViewBag.theTotalPage = CInstance.theMaterialsMananger.GetTotalPage();
            ViewBag.theMaterials = CInstance.theMaterialsMananger.GetBoard(1);
            return View();
        }
        [HttpGet]
        public ActionResult Materials(int page = 1)
        {
            ViewBag.theCurrentPage = page;
            ViewBag.theTotalPage = CInstance.theMaterialsMananger.GetTotalPage();
            ViewBag.theMaterials = CInstance.theMaterialsMananger.GetBoard(page);
            return (View());
        }

        [HttpPost]
        public ActionResult Materials(CMaterials aMaterials)
        {
            int tmpBool;
            tmpBool = CInstance.theMaterialsMananger.AddMaterials(ref aMaterials);
            if (tmpBool == 1)
            {
                return (RedirectToAction("Materials"));
            }

            return (View(aMaterials));
        }

        public ActionResult MaterialsDelete(int uid)
        {
            CInstance.theMaterialsMananger.MRemove(uid);
            return RedirectToAction("Materials");
        }
        public ActionResult MaterialsOK(CMaterials aMaterials)
        {

            int tmpBool;

            ViewBag.theWriter = aMaterials.theWriter;
            ViewBag.theTitle = aMaterials.theTitle;
            //ViewBag.theAttachFile = aMaterials.theAttachFile;
            ViewBag.theDate = aMaterials.theDate.ToString("yyyy.MM.dd");

            //"~/Material"
            //ViewBag.theAttachFile

            HttpPostedFileBase file = aMaterials.theFile;

            string ext = Path.GetExtension(file.FileName);
            //			string tmpFileName = Path.GetRandomFileName() + "." + ext;
            string tmpFileName = Path.GetRandomFileName() + ext;
            string path = Path.Combine(Server.MapPath("~/Material"), tmpFileName);
            file.SaveAs(path);
            //			aFileName = Path.GetFileName( file.FileName );
            //			aHDDName = tmpFileName;

            aMaterials.theFileName = file.FileName;
            aMaterials.theAttachFile = tmpFileName;

            tmpBool = CInstance.theMaterialsMananger.AddMaterials(ref aMaterials);
            //return View(aMaterials);\
            return RedirectToAction("Materials");
        }
/*        public ActionResult MaterialsModify(CMaterials aMaterials)
        {

            int tmpBool;

            ViewBag.theWriter = aMaterials.theWriter;
            ViewBag.theTitle = aMaterials.theTitle;
            //ViewBag.theAttachFile = aMaterials.theAttachFile;
            ViewBag.theDate = aMaterials.theDate.ToString("yyyy.MM.dd");

            //"~/Material"
            //ViewBag.theAttachFile

            HttpPostedFileBase file = aMaterials.theFile;

            string ext = Path.GetExtension(file.FileName);
            //			string tmpFileName = Path.GetRandomFileName() + "." + ext;
            string tmpFileName = Path.GetRandomFileName() + ext;
            string path = Path.Combine(Server.MapPath("~/Material"), tmpFileName);
            file.SaveAs(path);
            //			aFileName = Path.GetFileName( file.FileName );
            //			aHDDName = tmpFileName;

            aMaterials.theFileName = file.FileName;
            aMaterials.theAttachFile = tmpFileName;

            tmpBool = CInstance.theMaterialsMananger.AddMaterials(ref aMaterials);
            //return View(aMaterials);\
            return RedirectToAction("Materials");
        }*/
    }
}


/*@{

    Layout = null;
    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(@"~/images/"));
    int count = dir.GetFiles().Length;
    System.Diagnostics.Trace.WriteLine("/////////////" + count);




    string[] stringArray = new string[count];
    var j = 0;
    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Server.MapPath(@"~/images/"));

    foreach (var item in di.GetFiles())
    {
        // 파일 이름 출력
        stringArray[j] = item.Name;
        System.Diagnostics.Trace.WriteLine("FILE NAME : " + item.Name);
        j++;
    }

    var imagePath = "";
    imagePath = @"images/";




}*/