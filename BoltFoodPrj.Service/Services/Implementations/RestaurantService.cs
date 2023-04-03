using BoltFoodPrj.Core.Enums;
using BoltFoodPrj.Core.Models;
using BoltFoodPrj.Core.Repositories.RestaurantRepository;
using BoltFoodPrj.Data.Repositories.RestaurantRepository;
using BoltFoodPrj.Service.Services.Interfaces;
using BoltFoodPrj.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFoodPrj.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository = new restaurantRepository();
        public async Task<string> CreateAsync(string name, RestaurantCategoryEnum restaurantCategoryEnum)
        {
            Restaurant restaurant = new Restaurant(name, restaurantCategoryEnum);

            Console.ForegroundColor = ConsoleColor.Green;
            await _restaurantRepository.AddAsync(restaurant);
            return "Has been successfully created";
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _restaurantRepository.GetAllAsync();
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAysnc(x => x.Id == id);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input,Check again!");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            return restaurant;
        }

        public async Task<List<Product>> GetProductByRestaurant(string Name)
        {
            Restaurant restaurant = await _restaurantRepository.GetAysnc(x => x.name == Name);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input,Check again!");
                return null;
            }

            return restaurant.productsList;
        }

        public async Task<string> RemoveAsync(int Id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAysnc(x => x.Id == Id);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Restaurant is not found.";
            }

            await _restaurantRepository.RemoveAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Restaurant is removed succesfully";

        }

        public async Task<string> UpdateAsync(int Id, string name)
        {
            Restaurant restaurant = await _restaurantRepository.GetAysnc(x => x.Id == Id);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Wrong input again mate,there is no restaurant";
            }
            restaurant.name = name;
            await _restaurantRepository.UpdateAsync(restaurant);

            Console.ForegroundColor = ConsoleColor.Green;
            return "The Restaurant has been updated successfully";
        }

    }
}
