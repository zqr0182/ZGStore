﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.DTO
{
    public class ShippingDetails : Address
    {
        public bool GiftWrap { get; set; }
    }
}
