using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "PO Box")]
        public required string POBox { get; set; }
        [Display(Name = "Full Address")] 
        public string? FullAddress { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ValidateNever]
        public Customer Customer { get; set; }
        
    }
}
