using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Com.ViewModel
{
    public class User_ViewModel
    {

        [StringLength(50)]
        public required string Name { get; set; } = string.Empty;

        [RegularExpression(@"^\d{11}$")]
        public required string Phonenumber { get; set; } = string.Empty;

        [StringLength(16)]
        public required string Location { get; set; } = string.Empty;

        public required IFormFileCollection Images { get; set; }
 
    }
}
