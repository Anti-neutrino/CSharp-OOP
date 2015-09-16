using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCenter
{
   public class Product:IComparable
   {
       public string Name { get; set; }
       public double Price { get; set; }
       public string Producer { get; set; }

       public int CompareTo(object obj)
       {
           Product product = obj as Product;
           if (this.Name.CompareTo(product.Name) == 0)
           {
               if(this.Price.CompareTo(product.Price)==0)
               {
                   if(this.Producer.CompareTo(product.Producer)==0)
                   {
                       return 0;
                   }
                   return this.Producer.CompareTo(product.Producer);

               }
               return this.Price.CompareTo(product.Price);
           }
           else
           {
               return this.Name.CompareTo(product.Name);
           }
       }

       public override string ToString()
       {
           return string.Format("{{{0};{1};{2:0.00}}}",this.Name,this.Producer,this.Price);
       }
   }
}
