
namespace Shop
{
    internal class Goods
    {
        public string GoodName { get; private set; }
        public int GoodPrice { get; private set; }
        public int GoodCount { get; set; } //Количество продукта в сумке

        public Goods(string name, int prace)
        {
            GoodPrice = prace;
            GoodName = name;
            GoodCount = 1;
        }

    }
}
