﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class Book
    {
        //tworze model książki @bartuszak
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
    
}
