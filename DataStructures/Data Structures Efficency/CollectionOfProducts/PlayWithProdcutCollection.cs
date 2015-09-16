using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfProducts
{
    public class PlayWithProdcutCollection
    {
        static void Main()
        {
            ProductCollection collection = new ProductCollection();
            collection.Add(1995, "Momchil", "Yordanov", 50);
            collection.Add(1948, "Momchil", "Sofia", 100);
            collection.Add(1994, "Bojidar", "Sofia", 30);
            collection.Add(101, "Programirane", "Javaaa", 8);
            collection.Remove(1948);
            IEnumerable<Product> products = collection.FindProductBySupplierAndPrice("Sofia",100);

            foreach(var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
