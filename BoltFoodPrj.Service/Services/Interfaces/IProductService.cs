using BoltFoodPrj.Core.Enums;
using BoltFoodPrj.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoltFoodPrj.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<string> CreateAsync(int restoranId, string name, double price, ProductCategoryEnum category);
        public Task<string> UpdateAsync(int id, string name, double price);
        public Task<string> RemoveAsync(int id);
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetAllAsync();
    }
}
