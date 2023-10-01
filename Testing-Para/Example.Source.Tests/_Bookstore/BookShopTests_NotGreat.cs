using Example.Source._Bookstore;
using FluentAssertions;
using static Example.Source._Bookstore.BookShop;

namespace Potter.Tests
{
    public class BookShopTests_NotGreat
    {
        private readonly BookShop shop = new();

        [Fact]
        public void Calculate_NoBooksAdded_Returns_Zero()
        {
            var price = shop.Calculate();

            price.Should().Be(0);
        }

        // What if default price changes?
        [Fact]
        public void Calculate_OneBookAdded_Returns_Ten()
        {
            shop.Add(1);

            var price = shop.Calculate();

            price.Should().Be(10);
        }

        // Why 20?
        [Fact]
        public void Calculate_SameBookAdded_Returns_Twenty()
        {
            shop.Add(1, 1);
            
            var price = shop.Calculate();

            price.Should().Be(20);
        }

        // Impossible to name
        [Fact]
        public void Calculate_TwoDifferentBooks_Returns_NameThisValue()
        {
            shop.Add(1, 2);

            var price = shop.Calculate();

            price.Should().Be(20 * 0.95m);
        }

        // Need a calculator?
        [Fact]
        public void Calculate_TwoSameOneDifferentBooks_AppliesSingleDiscount()
        {
            shop.Add(1, 1, 2);

            var price = shop.Calculate();

            price.Should().Be(29);
        }

        [Fact(Skip = "Just an example of incomplete, overly complex assertion.")]
        public void Calculate_TwoSets_AppliesTwoDifferentDiscounts()
        {
            shop.Add(1, 2, 3);
            shop.Add(1, 2);

            var price = shop.Calculate();

            price.Should().Be(3 * 10 * (1 - 2 * 0.05m)); //+ ...);
        }
        [Fact]
        public void Calculate_FullSet_AppliesFullDiscount()
        {
            shop.Add(1, 2, 3, 4, 5, 6, 7, 8);

            var price = shop.Calculate();

            price.Should().Be(ExpectedSetPriceFor(8));
        }

        [Theory]
        [InlineData(-1)] // 0 already tested the boundary
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(1,2,3,9)] // Could be just 2 args
        public void Calculate_MinusOneBook_ThrowsException(params int[] bookId)
        {
            var invalidAdd = () => shop.Add(bookId);

            invalidAdd.Should().Throw<ArgumentException>();
        }

        // Not DRY.
        // But makes the tests DAMP.
        private decimal ExpectedSetPriceFor(int differentBooksCount) => DefaultBookPrice * differentBooksCount * (1 - (differentBooksCount - 1) * DefaultBookDiscount);
    }
}