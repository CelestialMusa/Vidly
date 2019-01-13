using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd yyyy}")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd yyyy}")]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        public GenreType GenreType { get; set; }
    }
}