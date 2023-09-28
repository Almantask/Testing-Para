namespace Potter
{
    // v1.1
    public class BookShop
    {
        public const int BookSetCount = 8;
        public const int DefaultBookPrice = 10;
        public const decimal DefaultBookDiscount = 0.05m;

        private readonly List<int> _items = new();

        public void Add(params int[] items)
        {
            Validate(items);
            _items.AddRange(items);
        }

        private static void Validate(int[] items)
        {
            Func<int, bool> predicate = i => i > 0 && i <= BookSetCount;
            var isValid = items.All(predicate);
            if (!isValid)
            {
                throw new ArgumentException();
            }
        }

        public decimal Calculate()
        {
            decimal sum = 0;
            var temp = new List<int>(_items);
            while (temp.Any())
            {
                int count = RemoveSet(temp);
                sum += CalculateSetPrice(count);
            }
            return sum;
        }

        private static int RemoveSet(List<int> temp)
        {
            int count = 0;
            for (int i = 0; i < BookSetCount; i++)
            {
                if (temp.Remove(i + 1))
                {
                    count++;
                }
            }

            return count;
        }

        private static decimal CalculateSetPrice(int count)
        {
            decimal discount = 1 - (count - 1) * DefaultBookDiscount;
            return count * DefaultBookPrice * discount;
        }
    }
}
