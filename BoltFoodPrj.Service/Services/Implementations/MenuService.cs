using BoltFoodPrj.Service.Services.Interfaces;
using BoltFoodPrj.Core.Enums;
using BoltFoodPrj.Core.Models;

namespace BoltFoodPrj.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IRestaurantService _restaurantservice = new RestaurantService();

        private readonly IProductService _productService = new ProductService();
        public void AnimatedWriteline(string message, ConsoleColor color)
        {
            int delay = 1;
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine();

        }
        public async Task ShowMenuAsync()
        {

            AnimatedWriteline("Bolt Food", ConsoleColor.Cyan);

            show();

            int.TryParse(Console.ReadLine(), out int request);

            while (request != 0)
            {
                switch (request)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestaurant();
                        break;

                    case 2:
                        Console.Clear();
                        await ShowAllRestaurant();
                        break;
                    case 3:
                        Console.Clear();
                        await GetRestaurant();
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateRestaurant();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestaurant();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        Console.Clear();
                        await ShowAllProducts();
                        break;
                    case 8:
                        Console.Clear();
                        await GetProduct();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateProduct();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveProduct();
                        break;

                    default:
                        Console.Clear();
                        AnimatedWriteline("Wrong Input", ConsoleColor.Red);
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                show();
                int.TryParse(Console.ReadLine(), out request);
            }
        }
        private void show()
        {
            AnimatedWriteline("1.Create a restaurant", ConsoleColor.DarkMagenta);
            AnimatedWriteline("2.Show Restaurant List", ConsoleColor.DarkMagenta);
            AnimatedWriteline("3.Show a restaurant", ConsoleColor.DarkMagenta);
            AnimatedWriteline("4.Update a restaurant", ConsoleColor.DarkMagenta);
            AnimatedWriteline("5.Remove a restaurant", ConsoleColor.DarkMagenta);
            AnimatedWriteline("------Product Options------", ConsoleColor.DarkMagenta);
            AnimatedWriteline("6.Create a product", ConsoleColor.DarkMagenta);
            AnimatedWriteline("7.Show Product List", ConsoleColor.DarkMagenta);
            AnimatedWriteline("8.Show a product", ConsoleColor.DarkMagenta);
            AnimatedWriteline("9.Update a product", ConsoleColor.DarkMagenta);
            AnimatedWriteline("10.Remove a product", ConsoleColor.DarkMagenta);

        }


        private async Task CreateRestaurant()
        {
            Console.WriteLine("Please add restaurant name");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                AnimatedWriteline("Name can not have Blank Space in it!", ConsoleColor.DarkRed);
                return;
            }


            Console.WriteLine("Please choose a Restaurant category");

            var Enums = Enum.GetValues(typeof(RestaurantCategoryEnum));

            foreach (var item in Enums)
            {

                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int restaurantCategory);

            try
            {
                Enums.GetValue(restaurantCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Input!");
                return;
            }



            string message = await _restaurantservice.CreateAsync(name, (RestaurantCategoryEnum)restaurantCategory);
            Console.WriteLine(message);
        }


        private async Task ShowAllRestaurant()
        {
            List<Restaurant> restaurants = await _restaurantservice.GetAllAsync();

            foreach (var item in restaurants)
            {
                AnimatedWriteline($"Restaurant ID {item.Id} Restaurant Name:{item.name} " +
                    $"Restaurant Category{item.RestaurantCategoryEnum}:", ConsoleColor.Green);
            }
        }


        private async Task GetRestaurant()
        {
            AnimatedWriteline("Enter ID Of the Restaurant", ConsoleColor.Cyan);
            int.TryParse(Console.ReadLine(), out int id);

            Restaurant restaurant = await _restaurantservice.GetAsync(id);
            Console.WriteLine($"Restaurant ID {restaurant.Id} Restaurant Name: {restaurant.name} " +
                $"Restaurant Category{restaurant.RestaurantCategoryEnum}");
        }

        private async Task UpdateRestaurant()
        {
            Console.WriteLine("Enter Restaurant ID that you want to Update");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Please enter Restoran");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add new name");
                return;

            }


            string message = await _restaurantservice.UpdateAsync(id, name);
            Console.WriteLine(message);
        }

        private async Task RemoveRestaurant()
        {
            AnimatedWriteline("Enter ID of the restaurant you want to Remove", ConsoleColor.DarkGreen);

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restaurantservice.RemoveAsync(id);
            Console.WriteLine(message);
        }


        private async Task CreateProduct()
        {
            Console.WriteLine("enter Restaurant ID");
            int restoranId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter product name that you want to Create");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Wrong input");
                return;

            }

            Console.WriteLine("enter product price");
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine("select category of the product");

            var Enums = Enum.GetValues(typeof(ProductCategoryEnum));
            foreach (var item in Enums)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int productcategory);

            try
            {
                Enums.GetValue(productcategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Input");
            }



            string message = await _productService.CreateAsync(restoranId, name, price, (ProductCategoryEnum)productcategory);
            Console.WriteLine(message);
        }

        private async Task ShowAllProducts()
        {
            List<Product> products = await _productService.GetAllAsync();

            foreach (Product product in products)
            {
                Console.WriteLine($"ProductId: {product.Id} ProductName: {product.name} Price:{product.Price} RestoranName:{product.Restaurant.name} ");
            }
        }

        private async Task GetProduct()
        {
            AnimatedWriteline("enter product id", ConsoleColor.Magenta);
            int.TryParse(Console.ReadLine(), out int id);

            Product product = await _productService.GetAsync(id);
            Console.WriteLine($"ProductName: {product.name} RestoranName: {product.Restaurant.name} ");
        }

        private async Task UpdateProduct()
        {
            Console.WriteLine("enter restaurant id number");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("enter name of the product you want to update");
            string name = Console.ReadLine();

            Console.WriteLine("enter product price");
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine("select category of product");

            var Enums = Enum.GetValues(typeof(ProductCategoryEnum));
            foreach (var item in Enums)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int productcategory);

            try
            {
                Enums.GetValue(productcategory);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must enter product category correctly");
            }


            string message = await _productService.UpdateAsync(id, name, price);
            Console.WriteLine(message);
        }

        private async Task RemoveProduct()
        {
            AnimatedWriteline("Please enter product id you want to delete", ConsoleColor.Cyan);

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _productService.RemoveAsync(id);
            Console.WriteLine(message);
        }
    }
}
