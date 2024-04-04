using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp10NewFeatures
{
    public record ProductRecord(int Id, string Name, double Price);

    //amaç class ve record karşılaştırması
    //public class ProductRecord
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public double Price { get; set; }

    //    public ProductRecord(int id, string name, double price)
    //    {
    //        Id = id;
    //        Name = name;
    //        Price = price;
    //    }
    //}


}
