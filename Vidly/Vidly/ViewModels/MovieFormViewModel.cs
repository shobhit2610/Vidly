using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public DateTime? DateAdded { get; set; }
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        [Required]
        public int? GenreId { get; set; }

        public IEnumerable<Genre> Genre{ get; set; }

        public MovieFormViewModel()
        {
            ID = 0;
            DateAdded = DateTime.Now;

        }
        public MovieFormViewModel(Movie movie)
        {
            ID=movie.ID;
            Name=movie.Name;
            ReleaseDate=movie.ReleaseDate;
            NumberInStock=movie.NumberInStock;
            GenreId = movie.GenreId;

        }
    }
}