
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using u21517208_HW03.Models;

namespace u21517208_HW03.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            //Fetch files/documents from directory
            string[] FilePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));

            //copy the file names and return the documents in a list

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in FilePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });

                

            }
            return View(files);
        }

        public FileResult Download(string fileName)
        {
            //file path
            string thepath = Server.MapPath("~/Media/Documents/") + fileName;

            //read the data into byte arrray and byte array
            byte[] bytesA = System.IO.File.ReadAllBytes(thepath);

            //send the document to download

            return File(bytesA, "application/octet-stream", fileName);

        }

        public ActionResult Delete(string fileName)
        {
            //file path
            string thepath = Server.MapPath("~/Media/Documents/") + fileName;

           
            byte[] bytesA = System.IO.File.ReadAllBytes(thepath);

            //delete
            System.IO.File.Delete(thepath);
            return RedirectToAction("Index");

        }
    }
    
}
