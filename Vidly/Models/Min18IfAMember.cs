using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.UNKNOWN || customer.MembershipTypeId == MembershipType.PAYASYOUGO )
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Customer Birthday Required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should at least be 18 years old to go on a membership");
        }
    }
}