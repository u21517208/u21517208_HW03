using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u21517208_HW03.Models
{
    public class FileModel
    {
        //Display options.

        [Display(Name = "File Name")]
        public string FileName 
        { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files 
        { get; set; }

    }
}