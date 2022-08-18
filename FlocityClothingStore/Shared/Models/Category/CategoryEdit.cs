﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Category
{
    public class CategoryEdit
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
   
    }
}
