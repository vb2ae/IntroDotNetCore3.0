using System;
using System.Collections.Generic;
using System.Text;

#nullable enable

namespace NullableDemo
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string AdditionalInfo { get; set; }

        public Product(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
    }
}
