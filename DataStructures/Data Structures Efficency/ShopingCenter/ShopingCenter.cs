using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShopingCenter
{
 

    public class ShopingCenter
    {
        private const string PRODUCT_ADDED = "Product added";
        private const string NO_PRODUCTS_FOUND = "No products found";
        private const string X_PRODUCTS_DELETED = " products deleted";
        private const string INCORRECT_COMMAND = "Incorect command";

        private MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        private MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
        private OrderedMultiDictionary<double, Product> productsByPrice = new OrderedMultiDictionary<double, Product>(true);
        private MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);

        public string AddProduct(string name,double price,string producer)
        {
            Product product = new Product() { Name = name, Price = price, Producer = producer };

            //Add by name
            productsByName.Add(name, product);

            //Add by producer
            productsByProducer.Add(producer, product);

            //Add by age
            productsByPrice.Add(price, product);

            //Add by name and producer
            var nameAndproducer = this.CombineNameAndProducer(name, producer);
            this.productsByNameAndProducer.Add(nameAndproducer, product);

            return PRODUCT_ADDED;
        }

        private string PrintPoducts(IEnumerable<Product> products)
        {
            List<Product> listOfProducts = new List<Product>(products);
            listOfProducts.Sort();

            StringBuilder builder = new StringBuilder();
            foreach(var product in listOfProducts)
            {
                builder.AppendLine(product.ToString());
            }

            string result = builder.ToString();
            string trimResult = result.TrimEnd();

            return trimResult;
        }

        private string FindProductsByName(string name)
        {
            if(this.productsByName.ContainsKey(name))
            {
                return this.PrintPoducts(productsByName[name]);
            }

            return NO_PRODUCTS_FOUND;
        }

        private IEnumerable<Product> FindProductsProducer(string producer)
        {
            if(productsByProducer.ContainsKey(producer))
            {
                return this.productsByProducer[producer];
            }

            return Enumerable.Empty<Product>();
        }

        private IEnumerable<Product> FindProductNameProducer(string name,string producer)
        {
            string nameProducer = this.CombineNameAndProducer(name, producer);
            if(this.productsByNameAndProducer.ContainsKey(nameProducer))
            {
                return this.productsByNameAndProducer[nameProducer];
            }

            return Enumerable.Empty<Product>();
        }

        private string DeleteProductsByNameAndProducer(string name,string producer)
        {
            IEnumerable<Product> products = this.FindProductNameProducer(name, producer);
            List<Product> listOfProducts = new List<Product>(products);
            int deletePoductsCounter = 0;

            foreach(var element in listOfProducts)
            {
                this.productsByName[element.Name].Remove(element);
                this.productsByProducer[element.Producer].Remove(element);
                this.productsByPrice[element.Price].Remove(element);
                var nameProducer = this.CombineNameAndProducer(name, producer);
                this.productsByNameAndProducer[nameProducer].Remove(element);
                deletePoductsCounter++;
            }

            if(listOfProducts.Count>0)
            {
                return deletePoductsCounter + X_PRODUCTS_DELETED;
            }

            return NO_PRODUCTS_FOUND;
        }

        private string DeleteProductsByProducer(string producer)
        {
            IEnumerable<Product> listOfProduct = this.FindProductsProducer(producer);
            List<Product> list = new List<Product>(listOfProduct);
            int counter = 0;
            foreach(var element in list)
            {
                this.productsByName[element.Name].Remove(element);
                this.productsByProducer[producer].Remove(element);
                this.productsByPrice[element.Price].Remove(element);
                var nameAndProducer = this.CombineNameAndProducer(element.Name, element.Producer);
                this.productsByNameAndProducer[nameAndProducer].Remove(element);
                counter++;
            }

            if(list.Count>0)
            {
                return counter + X_PRODUCTS_DELETED;
            }

            return NO_PRODUCTS_FOUND;
        }

        private string FindProductsByProducer(string producer)
        {
            if(this.productsByProducer.ContainsKey(producer))
            {
                return this.PrintPoducts(this.productsByProducer[producer]);
            }

            return NO_PRODUCTS_FOUND;
        }

        private string FindProductsByPrice(double startPrice,double endPrice)
        {
            List<Product> list = new List<Product>();

            var priceInRange = this.productsByPrice.Range(startPrice, true, endPrice, true);
            foreach(var prices in priceInRange)
            {
                foreach(var price in prices.Value)
                {
                    list.Add(price);
                }
            }

            if(list.Count>0)
            {
                return this.PrintPoducts(list);
            }

            return NO_PRODUCTS_FOUND;
        }

        private string CombineNameAndProducer(string name,string producer)
        {
            return name + "|!|" + producer;
        }

        public string ProccessComand(string command)
        {
            int firstIndex = command.IndexOf(' ');
            string method = command.Substring(0, firstIndex);
            string elements = command.Substring(firstIndex + 1);
            var parameters = elements.Split(';');

            switch (method)
            {
                case "AddProduct": return this.AddProduct(parameters[0], double.Parse(parameters[1]), parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return DeleteProductsByProducer(parameters[0]);
                    }
                    else
                    {
                        return this.DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                    }
                case "FindProductsByName": return FindProductsByName(parameters[0]);
                case "FindProductsByProducer": return FindProductsByProducer(parameters[0]);
                case "FindProductsByPriceRange": return this.FindProductsByPrice(double.Parse(parameters[0]),double.Parse(parameters[1]));
                default: return INCORRECT_COMMAND;
            }
        }
    }
}
