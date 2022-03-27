using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLayer.Services
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{2,}$",
         ErrorMessage = "Please enter correct price")]
        public int DiscountPrice { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{2,}$",
         ErrorMessage = "Please enter correct price")]
        public int OriginalPrice { get; set; }
        [Required]
        public string BookDescription { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int ReviewCount { get; set; }
        [Required]
        public int BookCount { get; set; }
    }
}
