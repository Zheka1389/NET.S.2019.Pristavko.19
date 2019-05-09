using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET.S._2019.Pristavko._19.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Display(Name = "Decription")]
        [Required]
        public String Decription { get; set; }

        [Display(Name = "Image Path")]
        public String ImagePath { get; set; }

        [Display(Name = "Thumb Path")]
        public String ThumbPath { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}