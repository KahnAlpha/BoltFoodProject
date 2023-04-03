﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodPrj.Service.Services.Interfaces
{
    public interface IMenuService
    {
        public Task ShowMenuAsync();
        public void AnimatedWriteline(string message, ConsoleColor color);
    }
}
