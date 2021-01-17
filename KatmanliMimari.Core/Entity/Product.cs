using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KatmanliMimari.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IdDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public virtual Category Category { get; set; }

    }
}
