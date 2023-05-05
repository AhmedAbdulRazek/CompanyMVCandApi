using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demo.BL.Models
{
    public class ForgetPasswordVM
    {

        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }

    }
}
