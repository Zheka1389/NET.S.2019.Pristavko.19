using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET.S._2019.Pristavko._19.Models
{
    public class PhotoToDB
    {
        [Key]
        public int PhotoId { get; set; }

        [Required(ErrorMessage = "Please enter a photo name")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}