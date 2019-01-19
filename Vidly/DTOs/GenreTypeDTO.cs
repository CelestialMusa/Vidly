using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class GenreTypeDTO
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}