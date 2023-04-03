using BoltFoodPrj.Service.Services.Implementations;
using BoltFoodPrj.Service.Services.Interfaces;
using System.ComponentModel.Design;

MenuService menuService = new MenuService();
await menuService.ShowMenuAsync();
IMenuService menuService2 = new MenuService();
menuService2.ShowMenuAsync();

