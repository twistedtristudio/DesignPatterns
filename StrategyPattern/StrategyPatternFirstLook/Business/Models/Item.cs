﻿namespace StrategyPatternFirstLook.Business.Models
{
    public class Item
    {
        public Item(string id, string name, decimal price, ItemType itemType)
        {
            Id = id;
            Name = name;
            Price = price;
            ItemType = itemType;
        }

        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public ItemType ItemType { get; set; }

        public decimal GetTax()
        {
            switch (ItemType)
            {
                case ItemType.Service:
                case ItemType.Food:
                case ItemType.Hardware:
                case ItemType.Literature:
                default:
                    return 0m;
            }
        }
    }
}