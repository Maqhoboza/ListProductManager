using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListProdManager.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        //[DataType(DataType.DateTime)]

        public string ProductCode { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

        public int Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        public Product()
        {

        }
    }
}


