using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLayer.Services
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$",
         ErrorMessage = "Please enter valid name")]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(@"^[a-z0-9]+(.[a-z0-9]+)?@[a-z]+[.][a-z]{3}$",
         ErrorMessage = "Please enter correct Email address")]
        public string EmailId { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z]).{8,}$",
        ErrorMessage = "Password Have minimum 8 Characters, Should have at least 1 Upper Case and Should have at least 1 numeric number and Has exactly 1 Special Character")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$",
         ErrorMessage = "Please enter correct phone number")]
        public string MobileNumber { get; set; }
    }
}
