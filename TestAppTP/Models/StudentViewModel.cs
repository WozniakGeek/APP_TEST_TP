using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppTP.Models
{
    public class StudentViewModel
    {
        [Required]        
        public int Document { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }
        [Required]
        
        public int Note1 { get; set; }
        [Required]
        
        public int Note2 { get; set; }
        [Required]
       
        public int Note3 { get; set; }

        public string Message { get; set; }
    }
}
