﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        CategoryManager ic = new CategoryManager(new EfCoreCategoryDal());
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                kategoriler = ic.GetALl()
            });
        }
    }
}
