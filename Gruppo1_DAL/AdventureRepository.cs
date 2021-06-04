using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppo1_Model;
using Gruppo1_Interfaces;
using Microsoft.Data.SqlClient;


namespace Gruppo1_DAL
{
    public class AdventureRepository : IAdventureRepository
    {
        private readonly string _connString;
        private AdventureDbContext _context;
        public AdventureRepository(string connString)
        {
            _connString = connString;
            var options = new DbContextOptionsBuilder<AdventureDbContext>()
                .UseSqlServer(_connString)
                .Options;
            _context = new AdventureDbContext(options);
        }
        public IEnumerable<Product> GetListProducts()
        {
            return _context.Set<Product>().AsQueryable();
        }
        public IEnumerable<ProductCategory> GetListCategories()
        {
            return _context.Set<ProductCategory>().AsQueryable();
        }
        public IEnumerable<ProductModel> GetListModels()
        {
            return _context.Set<ProductModel>().AsQueryable();
        }

        public void InsertProduct(Product item)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "InsertProduct";
                        //cmd.Parameters.Add(new SqlParameter("@ProductID", System.Data.SqlDbType.Int, 32)).Value = item.ProductID;
                        cmd.Parameters.Add(new SqlParameter("@ProductCategoryID", System.Data.SqlDbType.Int, 32)).Value = item.ProductCategoryId;
                        cmd.Parameters.Add(new SqlParameter("@ProductModelID", System.Data.SqlDbType.Int, 32)).Value = item.ProductModelId;
                        cmd.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 50)).Value = item.Name;
                        cmd.Parameters.Add(new SqlParameter("@ProductNumber", System.Data.SqlDbType.NVarChar, 25)).Value = item.ProductNumber;
                        cmd.Parameters.Add(new SqlParameter("@StandardCost", System.Data.SqlDbType.Decimal, 20)).Value = item.StandardCost;
                        cmd.Parameters.Add(new SqlParameter("@ListPrice" ,System.Data.SqlDbType.Decimal, 20)).Value = item.ListPrice;
                        cmd.Parameters.Add(new SqlParameter("@SellStartDate", System.Data.SqlDbType.DateTime)).Value = item.SellStartDate;
                        //cmd.Parameters.Add(new SqlParameter("@Rowguid", System.Data.SqlDbType.UniqueIdentifier)).Value = item.Rowguid;
                        cmd.Parameters.Add(new SqlParameter("@ModifiedDate", System.Data.SqlDbType.DateTime)).Value = item.ModifiedDate;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine(sqlex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            //return item.ProductId;
        }

        public void UpdateProduct(Product item)
        {
            Console.WriteLine("item", item);
            var dbItem = _context.Products.Single(e => e.ProductId == item.ProductId);
            if (dbItem != null)
            {
                dbItem.ProductModelId = item.ProductModelId;
                dbItem.Name = item.Name;
                dbItem.Name = item.ProductNumber;
                dbItem.StandardCost = item.StandardCost;
                dbItem.ListPrice = item.ListPrice;
                dbItem.SellStartDate = item.SellStartDate;
                dbItem.ModifiedDate = item.ModifiedDate;
                _context.Update(dbItem);
                _context.SaveChanges();
            }
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Single(e => e.ProductId == id);
        }

        public ProductCategory GetCategoryById(int? id)
        {
            return _context.Set<ProductCategory>().Single(e => e.ProductCategoryId == id);
        }
        public ProductModel GetModelById(int? id)
        {
            return _context.Set<ProductModel>().Single(e => e.ProductModelId == id);
        }

        public void DeleteProduct(int Id)
        {
            var dbItem = _context.Products.Single(e => e.ProductId == Id);
            if (dbItem != null)
            {
                _context.Remove(dbItem);
                _context.SaveChanges();
            }
        }
    }
}
