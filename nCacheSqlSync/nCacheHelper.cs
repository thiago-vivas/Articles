using System.Configuration;
using System.Data.SqlClient;
using Alachisoft.NCache.Client;
using Alachisoft.NCache.Runtime.Caching;
using Alachisoft.NCache.Runtime.Dependencies;
using System.Data;
using static nCacheSqlSync.NorthWindEntities;

namespace nCacheSqlSync
{
    public class nCacheHelper
    {

        private string connectionString;
        private ICache cache;
        public nCacheHelper()
        {
            this.InitializeCache();
        }

        private void InitializeCache()
        {
            string cache = ConfigurationManager.AppSettings["CacheID"];
            connectionString = ConfigurationManager.AppSettings["conn-string"];

            if (String.IsNullOrEmpty(cache))
            {
                Console.WriteLine("The Cache Name cannot be null or empty.");
                return;
            }

            // Initialize an instance of the cache to begin performing operations:
            this.cache = CacheManager.GetCache(cache);
        }


        public Product GetProduct(int productId)
        {
            string queryText = String.Format("SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM dbo.PRODUCTS WHERE PRODUCTID = {0}", productId);

            Product product = null;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                cmd.CommandText = queryText;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Populate product
                        product = new Product();
                        product.ProductID = (int)reader["ProductID"];
                        product.ProductName = reader["ProductName"] as String;
                        product.QuantityPerUnit = reader["QuantityPerUnit"] as String;
                        product.UnitPrice = (Decimal)reader["UnitPrice"];

                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("An error occured while fetching product. Error {0} ", ex));
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }

            return product;
        }
        public string AddProductToCacheWithDependency(Product product)
        {
            // Any change to the resultset of the query will cause cache to invalidate the dependent data
            string queryText = String.Format("SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM dbo.PRODUCTS WHERE PRODUCTID = {0}", product.ProductID);

            // Let's create SQL depdenency
            CacheDependency sqlServerDependency = new SqlCacheDependency(connectionString, queryText);

            CacheItem cacheItem = new CacheItem(product);
            cacheItem.Dependency = sqlServerDependency;

            // Inserting Loaded product into cache with key: [item:1]
            string cacheKey = GenerateProductCacheKey(product);
            this.cache.Add(cacheKey, cacheItem);

            return cacheKey;
        }
        public int UpdateProduct(Product product)
        {
            int rowsEffected = 0;
            string queryText = string.Format("UPDATE Products SET UnitPrice= {0} WHERE PRODUCTID = {1}", product.UnitPrice, product.ProductID);


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = queryText;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                rowsEffected = cmd.ExecuteNonQuery();

            }

            return rowsEffected;
        }
        public Product GetProductAutoReloadReadThroughProvider(int productId)
        {
            var product = new Product();
            string queryText = String.Format("SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM dbo.PRODUCTS WHERE PRODUCTID = {0}", productId);
            var sqlDependency = new SqlCacheDependency(connectionString, queryText);
            //-------------

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                cmd.CommandText = queryText;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Populate product
                        product.ProductID = (int)reader["ProductID"];
                        product.ProductName = reader["ProductName"] as String;
                        product.QuantityPerUnit = reader["QuantityPerUnit"] as String;
                        product.UnitPrice = (Decimal)reader["UnitPrice"];

                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("An error occured while fetching product. Error {0} ", ex));
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            // Create a new cache item and add sql dependency to it
            CacheItem item = new CacheItem(product);
            item.Dependency = sqlDependency;

            // Resync if enabled, will automatically resync cache with SQL server
            item.ResyncOptions = new ResyncOptions(true);

            //Add cache item in the cache with SQL Dependency and Resync option enabled
            this.cache.Insert(GenerateProductCacheKey(product), item);

            return product;
        }

        public Product GetProductParametrizedQuery(int productId)
        {
            var product = new Product();
            // Creating the query which selects the data on which the cache data is dependent
            // This query takes a parameter value at runtime and adds SQL Cache dependency to it
            string query = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM dbo.PRODUCTS WHERE PRODUCTID = @ProductID ";

            // Creating and populating the parameter 
            SqlCmdParams param = new SqlCmdParams();
            param.Type = CmdParamsType.Int;
            param.Value = productId;

            // Adding the populated parameter to a dictionary 
            var sqlParam = new Dictionary<string, SqlCmdParams>();
            sqlParam.Add("@ProductID", param);

            // Creating SQL dependency using parameterized query  
            var sqlDependency = new SqlCacheDependency(connectionString, query, SqlCommandType.Text, sqlParam);


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@ProductID", productId);

                sqlConnection.Open();

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Populate product
                        product.ProductID = (int)reader["ProductID"];
                        product.ProductName = reader["ProductName"] as String;
                        product.QuantityPerUnit = reader["QuantityPerUnit"] as String;
                        product.UnitPrice = (Decimal)reader["UnitPrice"];

                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("An error occured while fetching product. Error {0} ", ex));
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            // Create a new cache item and add sql dependency to it
            CacheItem item = new CacheItem(product);
            item.Dependency = sqlDependency;

            //Add cache item in the cache with SQL Dependency
            this.cache.Insert(GenerateProductCacheKey(product), item);

            return product;
        }

        public List<Order> GetOrdersStoredProcedureSqlDependency()
        {
            var result = new List<Order>();
            // The name of the stored procedure the item is dependent on
            string storedProcName = "CustOrdersOrders";

            // Specify the CustomerIDs passed as parameters
            var param = new SqlCmdParams();
            param.Type = CmdParamsType.NVarChar;
            param.Value = "ALFKI";

            Dictionary<string, SqlCmdParams> sqlCmdParams = new Dictionary<string, SqlCmdParams>();
            sqlCmdParams.Add("@CustomerID", param);

            // Create SQL Dependency
            // In case the stored procedure has no parameters pass null as the SqlCmdParams value
            SqlCacheDependency sqlDependency = new SqlCacheDependency(connectionString, storedProcName, SqlCommandType.StoredProcedure, sqlCmdParams);

            //  Get orders from database against given customer ID

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                cmd.CommandText = storedProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@CustomerID", param.Value);

                sqlConnection.Open();

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = new Order();
                        // Populate order

                        order.OrderID = Convert.ToInt32(reader["OrderID"].ToString());
                        order.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                        order.RequiredDate = Convert.ToDateTime(reader["RequiredDate"].ToString());
                        order.ShippedDate = Convert.ToDateTime(reader["ShippedDate"].ToString());

                        // Generate a unique cache key for this order
                        string key = GenerateOrderKey(order);

                        // Create a new cacheitem and add sql dependency to it
                        CacheItem item = new CacheItem(order);
                        item.Dependency = sqlDependency;

                        //Add cache item in the cache with SQL Dependency
                        this.cache.Insert(key, item);
                        result.Add(order);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("An error occured while fetching product. Error {0} ", ex));
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }

            return result;
        }

        public Product GetProductFromCache(string cacheKey)
        {
            return this.cache.Get<Product>(cacheKey);
        }
        public string GenerateOrderKey(Order order)
        {
            return $"Order#{order.OrderID}";
        }
        public string GenerateProductCacheKey(Product product)
        {
            string cacheKey = "Product#" + product.ProductID;
            return cacheKey;
        }
    }
}