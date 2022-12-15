﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryTypeId { get; set; }

        [ForeignKey("CategoryTypeId")]
        public CategoryType CategoryType { get; set; }
    }
}
