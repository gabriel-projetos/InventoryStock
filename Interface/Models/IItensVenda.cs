﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IItensVenda : IBaseModel
    {
        public double? Quantidade { get; set; }
        public decimal? Valor { get; set; }
    }
}
