﻿namespace ProductShop.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoryProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}