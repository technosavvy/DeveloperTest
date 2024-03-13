using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        // return new Product();
        // Assuming productIdentifier is unique
        return GetProductList().Where(pi=>pi.Identifier == productIdentifier).ToList().FirstOrDefault();
    }

    private static List<Product> GetProductList()
    {
        var ProductList = new List<Product>
        {
            new() { Id = 1, Identifier = "ProductIdentifier1", Price = 10.0m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "Uom" },
            new() { Id = 2, Identifier = "ProductIdentifier2", Price = 10.0m, SupportedIncentives = SupportedIncentiveType.FixedCashAmount, Uom = "Uom" },
            new() { Id = 3, Identifier = "ProductIdentifier3", Price = 10.0m, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "Uom" }
        };
        return ProductList;
    }
}