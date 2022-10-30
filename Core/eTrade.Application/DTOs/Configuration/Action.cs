using eTrade.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Application.DTOs.Configuration
{
    public class Action
    {
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Defination { get; set; }
        public string Code { get; set; }
    }
}
