using Practica4.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.Logic
{
    public class CategoryLogic : BaseLogic
    {
        public List<Categories> GetCategoriesAssociatedWithProducts()
        {
            var categoriesAssociatedWithProducts = _context.Categories
               .Where(category => category.Products.Any())
               .ToList();

            return categoriesAssociatedWithProducts;
        }
    }
}
