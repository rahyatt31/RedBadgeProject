﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [Required]
        public string PublisherName { get; set; }
        
        [Required]
        public string PublisherFounder { get; set; }
        
        [Required]
        public string PublisherLocation { get; set; }
        
        [Required]
        public int PublisherYearEstablished { get; set; }
        
        [Required]
        public string PublisherMostPopularGame { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}