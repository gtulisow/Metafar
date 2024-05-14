﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.infrastructure.DTOs.Response
{
    public class OperationResponseDto
    {
        public int Id { get; set; }
        public string OperationTypeName { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime OperationDateTime { get; set; }
    }
}
