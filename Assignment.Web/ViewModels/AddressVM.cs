using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment.Domain.Entities;

namespace Assignment.Web.ViewModels
{
    public class AddressVM
    {
        public Address? Address { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CustomerList { get; set; }
    }
}
