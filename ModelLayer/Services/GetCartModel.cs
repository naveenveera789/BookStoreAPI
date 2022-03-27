using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLayer.Services
{
    public class GetCartModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int OrderQuantity { get; set; }
        public BookModel bookModel { get; set; }
    }
}
