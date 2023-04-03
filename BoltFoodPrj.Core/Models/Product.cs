
using BoltFoodPrj.Core.Enums;
using BoltFoodPrj.Core.Models;
using BoltFoodPrj.Core.Models.Base;
using BoltFoodPrj.Core.Models;

public class Product : BaseModel
{
    private static int _id;
    public double Price { get; set; }
    public ProductCategoryEnum productCategoryEnum { get; set; }
    public Restaurant Restaurant { get; set; }
    public Product(Restaurant restaurant, string Name, double price, ProductCategoryEnum category) : base(Name)
    {
        _id++;
        Id = _id;
        name = Name;
        Price = price;
        productCategoryEnum = category;
        Restaurant = restaurant;
    }

    public override string ToString()
    {
        return $"Product id: {Id}, Product Name: {name}, Product price: {Price}," +
            $"Product category {productCategoryEnum}";
    }

}

