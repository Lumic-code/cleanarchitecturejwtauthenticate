﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities

{
    public class Product : BaseEntity
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
