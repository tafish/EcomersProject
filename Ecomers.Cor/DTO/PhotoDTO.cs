﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomers.Cor.DTO
{
    public record PhotoDTO
    {
        public string IimegName { get; init; }
        public int ProductId { get; set; }
    }
}
