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
        public IEnumerable<Category> GetListCategories()
        {
            return _context.Set<Category>().AsQueryable();
        }
        public IEnumerable<Model> GetListModels()
        {
            return _context.Set<Model>().AsQueryable();
        }

        public int InsertProduct(Product item)
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
                        cmd.Parameters.Add(new SqlParameter("@ProductCategoryID", System.Data.SqlDbType.Int, 32)).Value = 1;//item.ProductCategoryId;
                        cmd.Parameters.Add(new SqlParameter("@ProductModelID", System.Data.SqlDbType.Int, 32)).Value = 1;// item.ProductModelId;
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
            return item.ProductId;
        }
    }
}
