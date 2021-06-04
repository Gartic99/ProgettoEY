using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppo1_Model;

namespace Gruppo1_Interfaces
{
    public interface IAdventureRepository
    {
        IEnumerable<Product> GetListProducts();
        IEnumerable<ProductCategory> GetListCategories();
        IEnumerable<ProductModel> GetListModels();
        void InsertProduct(Product item);
        void UpdateProduct(Product item);

        Product GetProductById(int id);

        ProductCategory GetCategoryById(int? id);
        ProductModel GetModelById(int? id);
        void DeleteProduct(int Id);
    }
}
