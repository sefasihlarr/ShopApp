﻿using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{


    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopContext>, IProductDal
    {
        public IEnumerable<Product> GetPopularProduct()
        {
            throw new NotImplementedException();
        }
        //Kategoriye göre filtereleme işlemi
        public List<Product> GetProductsByCategory(string category, int page,int pageSize)
        {
            using (var contex = new ShopContext())

            {
                //ekstra sorgu gönderebilmek için "asQueryable" yi kullandik
                var products = contex.Products.AsQueryable();
                //category bilgisi eger null degilse categoryle gore filtreleme yaparız
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        //"Any"bize true yada false deger dondurur
                        .Where(x => x.ProductCategories.Any(a=>a.Category.Name.ToLower()==category.ToLower()));
                }
                //hangi saydaki ürünlerin alınacaginin yapıldıgı kısım
                return products.Skip((page-1) * pageSize).Take(pageSize).ToList();
            };
        }
    }
}
