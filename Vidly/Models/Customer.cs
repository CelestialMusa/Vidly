using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Customer Name Required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool isSubscribedToNewsLetter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18IfAMember]
        [Display(Name = "Date of birth")]
        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }
    }
}