﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IBasketProvider : IProvider<BasketDto>
    {
        BasketDto GetByOwner(int id);
    }
}
