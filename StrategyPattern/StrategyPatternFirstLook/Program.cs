using System;
using StrategyPatternFirstLook.Business.Models;

namespace StrategyPatternFirstLook
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("CSharpBook", "Some C# Book", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("Consulting", "Build Website", 100m, ItemType.Service), 1);

            Console.WriteLine(order.GetTax());
            Console.ReadLine();
        }
    }
}