using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string ISBN { set; get; }

        [Required(ErrorMessage ="Title for a book is required!")]
        public string Titile { get; set; }

        [Display(Name ="Publish Year")]
        public DateTime? PublishYear { get; set; }

        [Display(Name ="List Price")]
        public int ListPrice { get; set; }

        public int Price { get; set; }

        public string Author { get; set; }

        [Display(Name ="Category Name")]
        public int CategoryId { get; set; }

        [ForeignKey(name:"CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Display(Name ="Language")]
        public string LanguageId { get; set; }

        [ValidateNever]
        [ForeignKey(name:"LangaugeId")]
        public Language Language { get; set; }


        


    }
}
