using BoltFoodPrj.Core.Models;
using BoltFoodPrj.Core.Repositories.RestaurantRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodPrj.Data.Repositories.RestaurantRepository
{
    public class restaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
    }
}