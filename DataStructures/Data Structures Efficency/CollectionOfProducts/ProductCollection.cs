using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CollectionOfProducts
{
    public class Product:IComparable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Supplier { get; set; }
        public double Price { get; set; }

        public int CompareTo(object obj)
        {
            Product product = obj as Product;
            if(this.Id.CompareTo(product.Id)==0)
            {
                if(this.Title.CompareTo(product.Title)==0)
                {
                    if(this.Supplier.CompareTo(product.Supplier)==0)
                    {
                        if(this.Price.CompareTo(product.Price)==0)
                        {
                            return 0;   
                        }
                        else
                        {
                            return this.Price.CompareTo(product.Price);
                        }
                    }
                    else
                    {
                        return this.Supplier.CompareTo(product.Supplier);
                    }
                }
                else
                {
                    return this.Title.CompareTo(product.Title);
                }
            }
            else
            {
                return this.Id.CompareTo(product.Id);
            }
            
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("ID: "+this.Id+'\n');
            builder.Append("Title: "+this.Title+'\n');
            builder.Append("Supplier: "+this.Supplier+'\n');
            builder.Append("Price: "+this.Price+'\n');

            return builder.ToString();
        }
    }

    public class ProductCollection
    {
        private Dictionary<int, Product> productsByID = new Dictionary<int, Product>();
        private MultiDictionary<string, Product> productsByTitle = new MultiDictionary<string, Product>(true);
        private OrderedMultiDictionary<double, Product> productsByPrice = new OrderedMultiDictionary<double, Product>(true);
        private MultiDictionary<string, Product> productsByTitleAndPrice = new MultiDictionary<string, Product>(true);
        private Dictionary<string, OrderedMultiDictionary<double, Product>> productsByTitleAndPriceRange = new Dictionary<string, OrderedMultiDictionary<double, Product>>();
        private MultiDictionary<string, Product> productsBySupplierAndPrice = new MultiDictionary<string, Product>(true);
        private Dictionary<string, OrderedMultiDictionary<double, Product>> productsBySupplierAndPriceRange = new Dictionary<string, OrderedMultiDictionary<double, Product>>();

        private Product FindProductById(int id)
        {
            Product product;
            var newProduct = this.productsByID.TryGetValue(id,out product);
            return product;
        }

        public bool Add(int id,string title,string supplier,double price)
        {
            if(this.FindProductById(id)!=null)
            {
                return false;
            }

            Product product = new Product() { Id = id, Title = title, Supplier = supplier, Price = price };

            //Add by id
            this.productsByID.Add(id, product);

            //Add by title
            this.productsByTitle.Add(title, product);

            //Add by price
            this.productsByPrice.Add(price, product);

            //Add by title and price
            var titleAndPrice = this.CombineTitleAndPrice(title, price);
            this.productsByTitleAndPrice.Add(titleAndPrice, product);

            //Add by title and price range
            OrderedMultiDictionary<double, Product> dict;
            if(!this.productsByTitleAndPriceRange.TryGetValue(title,out dict))
            {
                dict = new OrderedMultiDictionary<double, Product>(true);
                this.productsByTitleAndPriceRange.Add(title, dict);
            }

            dict.Add(price, product);

            //Add by supplier and price
            string supplierAndPrice = this.CombineSupplierAndPrice(supplier, price);
            this.productsBySupplierAndPrice.Add(supplierAndPrice, product);

            //Add by supplier and price range
            OrderedMultiDictionary<double, Product> supDict;
            if(!this.productsBySupplierAndPriceRange.TryGetValue(supplier,out supDict))
            {
                supDict = new OrderedMultiDictionary<double, Product>(true);
                this.productsBySupplierAndPriceRange.Add(supplier, supDict);
            }

            supDict.Add(price, product);

            return true;
        }

        private string CombineSupplierAndPrice(string supplier,double price)
        {
            return supplier + "|!|" + price.ToString();
        }

        private string CombineTitleAndPrice(string title,double price)
        {
            return title + "|!|" + price.ToString();
        }

        public bool Remove(int id)
        {
            if(!this.productsByID.ContainsKey(id))
            {
                return false;
            }

            Product product = this.FindProductById(id);

            //Remove by id
            this.productsByID.Remove(id);
            this.productsByTitle[product.Title].Remove(product);
            this.productsByPrice[product.Price].Remove(product);
            string supplierAndPrice = this.CombineSupplierAndPrice(product.Supplier, product.Price);
            this.productsBySupplierAndPrice[supplierAndPrice].Remove(product);
            string titleAndPrice = this.CombineTitleAndPrice(product.Title, product.Price);
            this.productsByTitleAndPrice[titleAndPrice].Remove(product);
            this.productsByTitleAndPriceRange[product.Title][product.Price].Remove(product);
            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);

            return true;
        }

        public IEnumerable<Product> FindProdcutsByPriceRange(double startPrice,double endPrice)
        {
            var priceInRnage = this.productsByPrice.Range(startPrice, true, endPrice, true);
            foreach(var elements in priceInRnage)
            {
                foreach(var element in elements.Value)
                {
                    yield return element;
                }
            }
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            if(this.productsByTitle.ContainsKey(title))
            {
                return productsByTitle[title];
            }

            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title,double price)
        {
            string titleAndPrice = this.CombineTitleAndPrice(title, price);
            if(this.productsByTitleAndPrice.ContainsKey(titleAndPrice))
            {
                return this.productsByTitleAndPrice[titleAndPrice];
            }

            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title,double startPrice,double endPrice)
        {
            if(!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                yield break;
            }

            var priceInRange = this.productsByTitleAndPriceRange[title].Range(startPrice, true, endPrice, true);
            foreach(var elements in priceInRange)
            {
                foreach(var element in elements.Value)
                {
                    yield return element;
                }
            }
        }

        public IEnumerable<Product> FindProductBySupplierAndPrice(string supplier,double price)
        {
            var supplierAndPrice = this.CombineSupplierAndPrice(supplier, price);
            if(this.productsBySupplierAndPrice.ContainsKey(supplierAndPrice))
            {
                return this.productsBySupplierAndPrice[supplierAndPrice];
            }

            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Product> FindPersongBySupleirAndPriceRange(string supplier,double startPrice,double endPrice)
        {
            if(!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                yield break;
            }

            var priceInRange = this.productsBySupplierAndPriceRange[supplier].Range(startPrice, true, endPrice, true);
            foreach(var elements in priceInRange)
            {
                foreach(var element in elements.Value)
                {
                    yield return element;
                }
            }
        }
    }


}
