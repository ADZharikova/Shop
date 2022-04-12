using System;
using System.Collections.Generic;

namespace Shop
{
    internal class Customer
    {
        public List<Goods> Bag { get; private set; } = new List<Goods>();
        public int CustomerMoney { get; private set; }
        private int _j = 0;
        private int _i = 1;

        public Customer(int money)
        {
            CustomerMoney = money;
        }
        public void Buy(string buy, int price)
        {
            CustomerMoney -= price;
            if (CustomerMoney < 0)
            {
                Console.WriteLine("Недостаточно монет.");
                CustomerMoney += price;
            }
            else
            {
                foreach (var item in Bag)
                {
                    if (item.GoodName == buy)
                    {
                        item.GoodCount++;
                        _j = 1;
                    }
                }

                if (_j == 0)
                {
                    Bag.Add(new Goods(buy, 0));
                }

                _j = 0;
            }

        }

        public void ShowAllGoods()
        {

            Console.SetCursorPosition(90, 3);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Монет: {CustomerMoney}");
            Console.ResetColor();
            Console.SetCursorPosition(90, 5);

            Console.WriteLine("В сумке:");
            foreach (var item in Bag)
            {
                Console.SetCursorPosition(90, 6 + _i);
                Console.WriteLine($"{item.GoodName} {item.GoodCount}");
                _i++;
            }

            _i = 1;
        }
    }
}
