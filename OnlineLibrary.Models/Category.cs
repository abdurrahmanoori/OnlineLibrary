using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineLibrary.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name ="Category Type")]
        public int CategoryTypeId { get; set; }

        [ForeignKey("CategoryTypeId"),ValidateNever]
        public CategoryType CategoryType { get; set; }
    }
}
