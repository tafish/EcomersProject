﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Cor.Entites.Product
{
    public class Photo :BaseEntity<int>
    {
        public string IimegName { get; init; }

        public int ProductId { get; set; }

        //[ForeignKey(nameof(ProductId))]
        //public virtual Product Product { get; init; }
    }
}
