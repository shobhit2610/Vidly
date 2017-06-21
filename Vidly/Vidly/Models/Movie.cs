using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
       
        public string DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}