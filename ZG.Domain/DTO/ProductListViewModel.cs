﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Domain.DTO
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductBriefInfo> Products { get; set; }
        public int TotalProducts { get; set; }
    }
}