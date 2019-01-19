using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool isSubscribedToNewsLetter { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}