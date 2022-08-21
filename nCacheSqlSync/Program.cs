// See https://aka.ms/new-console-template for more information
using nCacheSqlSync;

Console.WriteLine("Hello, World!");
nCacheHelper nCacheHelper = new nCacheHelper();

int productId = 1;
// Fetch a sample product from the database 
var product = nCacheHelper.GetProduct(productId);

// Add product to the cache with SQL Dependency
var cacheKey = nCacheHelper.AddProductToCacheWithDependency(product);

if (nCacheHelper.GetProductFromCache(cacheKey) == null)
    Console.WriteLine("Product not found in cache.");
else
    Console.WriteLine("Product found in cache.");

//// Update Product in northwind db to trigger sql server dependency
nCacheHelper.UpdateProduct(product);

//// Verify dependency being triggered
if (nCacheHelper.GetProductFromCache(cacheKey) == null)
    Console.WriteLine("Product not found in cache.");
else
    Console.WriteLine("Product found in cache.");

//stored procedure dependency
var orders = nCacheHelper.GetOrdersStoredProcedureSqlDependency();


//auto reload 
var productAutoReload = nCacheHelper.GetProductAutoReloadReadThroughProvider(productId + 1);
var autoReloadCacheKey = nCacheHelper.GenerateProductCacheKey(productAutoReload);

if (nCacheHelper.GetProductFromCache(autoReloadCacheKey) == null)
    Console.WriteLine("productAutoReload not found in cache.");
else
    Console.WriteLine("productAutoReload found in cache.");

//// Update Product in northwind db to validate cache sync
nCacheHelper.UpdateProduct(productAutoReload);

if (nCacheHelper.GetProductFromCache(autoReloadCacheKey) == null)
    Console.WriteLine("productAutoReload not found in cache.");
else
    Console.WriteLine("productAutoReload found in cache.");

//parametrized query
var productParametrized = nCacheHelper.GetProductParametrizedQuery(productId + 2);
var productParametrizedCacheKey = nCacheHelper.GenerateProductCacheKey(productParametrized);


if (nCacheHelper.GetProductFromCache(productParametrizedCacheKey) == null)
    Console.WriteLine("productParametrized not found in cache.");
else
    Console.WriteLine("productParametrized found in cache.");
