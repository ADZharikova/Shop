using System;
using System.Collections.Generic;

namespace Shop
{
    internal class Seller
    {
        public List<Goods> Shop { get; private set; } = new List<Goods>();
        private int _i = 1;


        public void AddGood(string name, int price)
        {
            Shop.Add(new Goods(name, price));
        }

        public void ShowAllGoods()
        {
            Console.SetCursorPosition(60, 5);
            Console.WriteLine("У торговца:");
            foreach (var item in Shop)
            {
                Console.SetCursorPosition(60, 6 + _i);
                Console.WriteLine($"{item.GoodName}: {item.GoodPrice}");
                ++_i;
            }

            _i = 1;
        }


        public string Sell(string name)
        {
            foreach (var item in Shop)
            {
                if (name.ToLower() == item.GoodName.ToLower())
                {
                    return item.GoodName;
                }
            }

            return "Товар не найден";
        }

        public int FindOutThePrice(string name)
        {
            foreach (var item in Shop)
            {
                if (name.ToLower() == item.GoodName.ToLower())
                {
                    return item.GoodPrice;
                }
            }

            return 0;
        }

    }
}
