﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Application.Abstraction.Services
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string text);
    }
}
