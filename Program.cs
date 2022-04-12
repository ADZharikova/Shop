using System;
using System.IO;
using System.Collections.Generic;

namespace Shop
{
    internal class Program
    {
        static Dictionary<string, string> AddGoods(string name, char delimiter)
        {
            Dictionary<string, string> goodPrice = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(name))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] keyvalye = line.Split(delimiter);
                    if (keyvalye.Length == 2)
                    {
                        goodPrice.Add(keyvalye[0], keyvalye[1]);
                    }
                }
            }

            return goodPrice;
        }

        static void Main(string[] args)
        {

            Dictionary<string, string> readGoodsOfFile;
            string name = "Goods.txt";
            char delimiter = '=';

            Seller seller = new Seller();
            Customer customer = new Customer(645);
            string NameOfGood;
            string buy;
            bool isOpen = true;
            string putUser;
            int price;

            readGoodsOfFile = AddGoods(name, delimiter);

            foreach (var item in readGoodsOfFile) //Добавление товаров торговцу
            {
                var valuePrice = Convert.ToInt32(item.Value);
                seller.AddGood(item.Key, valuePrice);
            }

            while (isOpen)
            {
                Console.SetCursorPosition(40, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Добро пожаловать в лавку!");
                Console.WriteLine();

                Console.ResetColor();

                seller.ShowAllGoods();
                customer.ShowAllGoods();
                Console.WriteLine();

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Что хотите купить?");
                NameOfGood = Console.ReadLine();
                buy = seller.Sell(NameOfGood);
                if (buy == "Товар не найден")
                {
                    Console.WriteLine(buy);
                }
                else
                {
                    price = seller.FindOutThePrice(buy);
                    customer.Buy(buy, price);
                }

                customer.ShowAllGoods();

                Console.SetCursorPosition(0, 7);
                Console.WriteLine();
                Console.WriteLine("Хотите выйти? (д/н)");
                putUser = Console.ReadLine();

                switch (putUser.ToLower())
                {
                    case "д":
                        isOpen = false;
                        break;

                    case "н":
                        Console.WriteLine("Для продолжения нажмите любую кнопку");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Команда не расшифрована, Вас отправят обратно в магазин.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
