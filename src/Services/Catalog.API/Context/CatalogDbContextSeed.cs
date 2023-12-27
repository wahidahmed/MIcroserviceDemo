using Catalog.API.Manager;

namespace Catalog.API.Context
{
    public class CatalogDbContextSeed
    {
        static ProductManager _productManager = new ProductManager();

        public static void Seed()
        {
            var product = _productManager.GetFirstOrDefault(c => true);
            if (product == null)
            {

            }
        }
    }
}
