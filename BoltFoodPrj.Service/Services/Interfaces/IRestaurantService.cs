using BoltFoodPrj.Core.Enums;
using BoltFoodPrj.Core.Models;
using BoltFoodPrj.Data.Repositories.RestaurantRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFoodPrj.Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<string> CreateAsync(string name, RestaurantCategoryEnum restaurantCategoryEnum);
        public Task<string> UpdateAsync(int Id, string name);
        public Task<string> RemoveAsync(int Id);
        public Task<Restaurant> GetAsync(int id);
        public Task<List<Restaurant>> GetAllAsync();





    }
}
