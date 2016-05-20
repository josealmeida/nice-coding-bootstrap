﻿using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// IProductRepository interface
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
