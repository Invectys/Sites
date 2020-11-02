using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class CreateArticleModel
    {
        public int Id{ get; set; }
        public bool Personal { get; set; }
        [Required, StringLength(15, MinimumLength = 0, ErrorMessage = "Max Lenght of title 15 ")]
        public string Title { get; set; }

        [Required]
        //[FileExtensions(Extensions = "image/jpg,image/png,image/jpeg")]
        public IFormFile Img { get; set; }

        [StringLength(100)]
        public string JSONImageData { get; set; }

        public string JSONArticleData { get; set; }


        [Required, StringLength(600, MinimumLength = 0, ErrorMessage = "Max Lenght of infotmation 600")]
        public string Information { get; set; }

        public string User { get; set; }
    }
}
