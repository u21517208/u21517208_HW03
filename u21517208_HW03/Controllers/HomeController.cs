
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21517208_HW03.Controllers
{
    public class HomeController : Controller
    { 
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string TypeOfFile, HttpPostedFileBase thefile )
        {
            //check whether a file was uploaded
            if (thefile != null)
            {
                string getfiles = Path.GetFileName(thefile.FileName);

                if (TypeOfFile == "Documents")
                {
                    thefile.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), Path.GetFileName(thefile.FileName)));
                    

                }
                else if (TypeOfFile == "Images")
                {
                    thefile.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), Path.GetFileName(thefile.FileName)));
                    
                }
                else if (TypeOfFile == "Videos")
                {
                    thefile.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos"), Path.GetFileName(thefile.FileName)));
                    
                }
            }
            else//message that will show when file is not selected
            {
                ViewBag.Message = "Select file";
            }
          

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

       
    }
}