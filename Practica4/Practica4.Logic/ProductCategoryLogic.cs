using Practica4.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.Logic
{
    public class ProductCategoryLogic : BaseLogic
    {
        public List<ProductCategory> GetProductCategories()
        {
            var productCategories = _context.Products
                .Join(
                    _context.Categories,
                    product => product.CategoryID,
                    category => category.CategoryID,
                    (product, category) => new ProductCategory
                    {
                        ProductName = product.ProductName,
                        CategoryName = category.CategoryName
                    })
                .ToList();

            return productCategories;
        }

    }
}
