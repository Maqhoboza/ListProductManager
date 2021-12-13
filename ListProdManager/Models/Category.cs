using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListProdManager.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //[StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        [RegularExpression(@"\d{3}[a-zA-Z]{3}$")]
        [Required]
        public string CategoryCode { get; set; }
        public bool IsActive { get; set; }

        public Category()
        {

        }

    }
}
