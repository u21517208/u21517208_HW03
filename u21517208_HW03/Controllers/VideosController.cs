using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using u21517208_HW03.Models;

namespace u21517208_HW03.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult Index()
        {
            //Fetch files/documents from directory
            string[] FileDirectory = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));

            //copy the file names and return the documents in a list

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in FileDirectory)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });

                return View(files);
            }
            return View(files);
        }

        public FileResult Download(string fileName)
        {
            //file path
            string path = Server.MapPath("~/Media/Videos/") + fileName;

            //read the data into byte arrray and byte array
            byte[] bytesA = System.IO.File.ReadAllBytes(path);

            //send the document to download

            return File(bytesA, "application/octet-stream", fileName);

        }

        public ActionResult Delete(string fileName)
        {
            //file path
            string path = Server.MapPath("~/Media/Videos/") + fileName;


            byte[] bytesA = System.IO.File.ReadAllBytes(path);

            //delete
            System.IO.File.Delete(path);
            return RedirectToAction("Index");

        }
    }
}