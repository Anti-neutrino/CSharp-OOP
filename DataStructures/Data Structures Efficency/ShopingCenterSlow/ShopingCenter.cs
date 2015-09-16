using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopingCenterSlow
{
    public class ShopingCenter
    {
        private const string PRODUCT_ADDED = "Product added";
        private const string NO_PRODUCTS_FOUND = "No products found";
        private const string X_PRODUCTS_DELETED = " products deleted";
        private const string INCORRECT_COMMAND = "Incorect command";

        private List<Product> products = new List<Product>();

        private string Add(string name,decimal price,string producer)
        {
            Product prod = new Product() { Name = name, Price = price, Producer = producer };

            products.Add(prod);
            return PRODUCT_ADDED;
        }

        private string FindProductsByName(string name)
        {
            var products = this.products.Where(p => p.Name == name).OrderBy(p => p);
            return PrintProducts(products);
        }

        private string FindProductsByProducer(string producer)
        {
            var products = this.products.Where(p => p.Producer == producer).OrderBy(p => p);
            return PrintProducts(products);
        }

        private string FindProductsByPriceRange(decimal startprice,decimal endPrice)
        {
            var products = this.products.Where(p => startprice <= p.Price && p.Price <= endPrice).OrderBy(p => p);
            return PrintProducts(products);
        }

        private string DeleteProductsByNameAndProducer(string name,string producer)
        {
            int count = this.products.RemoveAll(p => p.Name == name && p.Producer == producer);
            if(count>0)
            {
                return count + X_PRODUCTS_DELETED;
            }

            return NO_PRODUCTS_FOUND;
        }

        private string DeleteProductsByProducer(string producer)
        {
            int count = this.products.RemoveAll(p => p.Producer == producer);

            if(count>0)
            {
                return count + X_PRODUCTS_DELETED;
            }

            return NO_PRODUCTS_FOUND;
        }

        public string ProccessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters =
                parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (method)
            {
                case "AddProduct":
                    return Add(parameters[0], decimal.Parse(parameters[1]), parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return DeleteProductsByProducer(parameters[0]);
                    }
                    else
                    {
                        return DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                    }
                case "FindProductsByName":
                    return FindProductsByName(parameters[0]);
                case "FindProductsByPriceRange":
                    return FindProductsByPriceRange(decimal.Parse(parameters[0]),decimal.Parse(parameters[1]));
                case "FindProductsByProducer":
                    return FindProductsByProducer(parameters[0]);
                default:
                    return INCORRECT_COMMAND;
            }
        }


        private string PrintProducts(IEnumerable<Product> products)
        {
            if(products.Any())
            {
                StringBuilder builder = new StringBuilder();
                foreach(var product in products)
                {
                    builder.AppendLine(product.ToString());
                }

                return builder.ToString().TrimEnd();
            }
            return NO_PRODUCTS_FOUND;
        }

    }
}
