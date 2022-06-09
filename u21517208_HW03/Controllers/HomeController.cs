
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
        public ActionResult Index( HttpPostedFileBase file )
        {
            //check whether a file was uploaded
            if (file != null && file.ContentLength>0)
            {
                var Type = Request["TypeOfFile"];
                string getfiles = Path.GetFileName(file.FileName);

                if (Type == "Documents")
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Media/Documents"), Path.GetFileName(file.FileName)));
                    

                }
                else if (Type == "Images")
                {
                   file.SaveAs(Path.Combine(Server.MapPath("~/Media/Images"), Path.GetFileName(file.FileName)));
                    
                }
                else if (Type == "Videos")
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Media/Videos"), Path.GetFileName(file.FileName)));
                    
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