using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); 
        void CreateProduct(string name, int price, int categoryID); 

    }
}
