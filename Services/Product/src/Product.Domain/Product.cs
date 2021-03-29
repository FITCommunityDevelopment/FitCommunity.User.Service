﻿using System;
using System.Collections.Generic;

namespace Product.Domain
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
