using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactManagement.Models
{
    public class mvcContactModel
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage ="This Field is Required")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}