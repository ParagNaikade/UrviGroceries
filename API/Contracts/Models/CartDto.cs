using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Models
{
    public class CartDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }
    }
}
