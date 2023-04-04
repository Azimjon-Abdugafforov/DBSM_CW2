using DBSD_CW2.Models;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DBMS_CW_last.Repo
{
    public class ProductRepository : IProductsRepo
    {

        private string ConnStr
        {
            get
            {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AppData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
        }
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> Filter(string name, bool onSale, int categoryId, decimal price)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            IList<Product> products = new List<Product>();

            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Products";
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var product = new Product();
                            product.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                            product.Name = rdr.GetString(rdr.GetOrdinal("Name"));
                            product.Description = rdr.GetString(rdr.GetOrdinal("Description"));
                            product.Price = rdr.GetDecimal(rdr.GetOrdinal("Price"));
                            product.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal("ExpirationDate"));
                            product.CategoryId = rdr.GetInt32(rdr.GetOrdinal("CategoryId"));
                            //product.ImageData = rdr.GetByte(rdr.GetOrdinal("ImageData"));

                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public Product GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                 using (var cmd = conn.CreateCommand())
                 {
                    cmd.CommandText = @"INSERT";

                    var categoryIdParam = cmd.CreateParameter();
                    categoryIdParam.ParameterName = "@CategoryId";
                    categoryIdParam.DbType = System.Data.DbType.Int32;
                    categoryIdParam.Value = product.CategoryId;
                    categoryIdParam.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(categoryIdParam);


                    cmd.Parameters.AddWithValue("Name", product.Name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Description", product.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("ExpirationDate", product.ExpirationDate);
                    cmd.Parameters.AddWithValue("Price", product.Price);
                    cmd.Parameters.AddWithValue("CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("OnSale", product.OnSale);
                    cmd.Parameters.AddWithValue("ImageData", product.ImageData);
                        conn.Open();

                        cmd.ExecuteNonQuery();
                 }
            }
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
