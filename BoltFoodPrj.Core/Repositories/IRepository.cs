﻿using BoltFoodPrj.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodPrj.Core.Repositories
{
    public interface IRepository<T>
    {
        public Task AddAsync(T model);
        public Task UpdateAsync(T model);
        public Task RemoveAsync(T model);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAysnc(Func<T, bool> expression);
    }
}
