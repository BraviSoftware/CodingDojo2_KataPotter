using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraviDojo2
{
    public class SaleCalculator
    {
        const Decimal BOOK_PRICE = 40;
        public decimal Calculate(List<int> basket)
        {
            if (!basket.Any())
                return 0;

            var totalPrice = 0m;

            while (basket.Any())
            {
                var distinctBooks = basket.Distinct().ToArray();
                var priceFactor = CalculatePriceFactorByNumberOfBooks(distinctBooks.Count());
                totalPrice += distinctBooks.Count()*BOOK_PRICE*priceFactor;

                foreach (var distinctBook in distinctBooks)
                    basket.Remove(distinctBook);
            }


            return totalPrice;
        }

        private decimal CalculatePriceFactorByNumberOfBooks(int numberOfBooks)
        {
            switch (numberOfBooks)
            {
                case 2:
                    return 0.95m;
                case 3:
                    return 0.90m;
                case 4:
                    return 0.80m;
                case 5:
                    return 0.75m;
                default:
                    return 1;
            }
        }
    }
}
