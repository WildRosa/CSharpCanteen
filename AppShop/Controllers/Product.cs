using AppShop.Entities;
using AppShop.Extensions;
using AppShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AppShop.Data;

namespace AppShop.Controllers
{
    public class Product : Controller
    {

        ApplicationDbContext _context;
        int _pageSize;


        public Product(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);

            ViewData["Groups"] = _context.DishGroups;

            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else return View(model);
            //return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }


       /* private void SetupData()
        {
            _dishGroups = new List<DishGroup> { 
            
                new DishGroup {DishGroupId= 1, GroupName="Стартеры"},
                new DishGroup {DishGroupId= 2, GroupName="Салаты"},
                new DishGroup {DishGroupId= 3, GroupName="Супы"},
                new DishGroup {DishGroupId= 4, GroupName="Основное блюдо"},
                new DishGroup {DishGroupId= 1, GroupName="Напитки"},
                new DishGroup {DishGroupId= 1, GroupName="Десерты"}

            };


            _dishes = new List<Dish> { 
            
                new Dish{DishId = 1, DishName = "Суп-харчо", Description ="Очень острый, невкусный", Calories = 200, DishGroupId = 3, Image = "Суп.jpg"},
                new Dish{DishId = 2, DishName = "Борщ", Description ="Много сала, без сметаны", Calories = 330, DishGroupId = 3, Image = "Борщ.jpg"},
                new Dish{DishId = 3, DishName = "Котлета пожарская", Description ="Хлеб - 80%, Морковь - 20%", Calories = 635, DishGroupId = 4, Image = "Котлета.jpg"},
                new Dish{DishId = 4, DishName = "Макароны по-флотски", Description ="С охотничьей колбаской", Calories = 524, DishGroupId = 4, Image = "Макароны.jpg"},
                new Dish{DishId = 5, DishName = "Компот", Description ="Быстро растворимый, 2 литра", Calories = 180, DishGroupId = 5, Image = "Компот.jpg"}
            };
        }
       */
    }
}
