using Practica4.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> GetProductsWithoutStock()
        {
            var productsWithoutStock = from product in _context.Products
                                       where product.UnitsInStock == 0
                                       select product;
            return productsWithoutStock.ToList();
        }
        
        public List<Products> SearchProductsWithAdequateStock()
        {
            var productsWithAdequateStock = from product in _context.Products
                                            where product.UnitsInStock > 3
                                            select product;
            return productsWithAdequateStock.ToList();
        }

        public Products GetProductById789()
        {
            var producto789 = _context.Products.FirstOrDefault(producto => producto.ProductID == 789);

            return producto789;
        }

        public List <Products> GetProductsOrderedByName()
        {
            var productsOrderedByName = (from product in _context.Products
                                         orderby product.ProductName
                                         select product).ToList();

            return productsOrderedByName;
        }

        public List<Products> GetproductOrderedByStock()
        {
            var productOrderedByStock = _context.Products
                .OrderByDescending(p => p.UnitsInStock)
                .ToList();

            return productOrderedByStock;
        }

        public Products GetFirstProduct()
        {
            return _context.Products.FirstOrDefault();
        }
    }
}
