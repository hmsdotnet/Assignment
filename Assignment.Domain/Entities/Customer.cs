using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }        
        [Display(Name = "Mobile Number")]
        [Phone]
        public string? MobileNumber { get; set; }  // Customer's mobile number
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? EmailAddress { get; set; }  // Customer's email address

        [Range(1, 150)]
        public int Age { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }

        [ValidateNever]
        public IEnumerable<Address> CustomerAddress { get; set; }
    }
}
