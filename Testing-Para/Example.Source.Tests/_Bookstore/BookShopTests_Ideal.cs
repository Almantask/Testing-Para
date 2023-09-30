using Example.Source._Bookstore;
using FluentAssertions;
using static Example.Source._Bookstore.BookShop;

namespace Potter.Tests
{
    public class BookShopTests_Calculate
    {
        private readonly BookShop shop = new();

        [Fact]
        public void Calculate_NoBooksAdded_Returns_Zero()
        {
            var price = shop.Calculate();

            price.Should().Be(0);
        }

        [Fact]
        public void OneBookAdded_Returns_PriceOfABook()
        {
            shop.Add(1);

            var price = shop.Calculate();

            // Using constant
            price.Should().Be(BookShop.DefaultBookPrice);
        }

        [Fact]
        public void SameBookAdded_Returns_DoubleThePriceOfABook()
        {
            shop.Add(1, 1);
            
            var price = shop.Calculate();

            // Using constant as static import
            price.Should().Be(DefaultBookPrice * 2);
        }

        [Fact]
        public void TwoDifferentBooks_Returns_DiscountedSet()
        {
            shop.Add(1, 2);

            var price = shop.Calculate();

            price.Should().Be(ExpectedSetPriceFor(2));
        }

        [Fact]
        public void TwoSameOneDifferentBooks_DiscountedSet_Plus_FullSingleBookPrice()
        {
            shop.Add(1, 1, 2);

            var price = shop.Calculate();

            price.Should().Be(DefaultBookPrice + ExpectedSetPriceFor(2));
        }

        [Fact]
        public void TwoSets_Returns_DifferentDiscountsApplied_ForEachSet()
        {
            shop.Add(1, 2, 3);
            shop.Add(1, 2);

            var price = shop.Calculate();

            price.Should().Be(ExpectedSetPriceFor(3) + ExpectedSetPriceFor(2));
        }
        [Fact]
        public void FullSet_Returns_FullyDiscountedPrice()
        {
            shop.Add(1, 2, 3, 4, 5, 6, 7, 8);

            var price = shop.Calculate();

            price.Should().Be(ExpectedSetPriceFor(8));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(1,2,3,9)]
        public void InvalidBook_ArgumentException(params int[] bookId)
        {
            var invalidAdd = () => shop.Add(bookId);

            invalidAdd.Should().Throw<ArgumentException>();
        }

        private decimal ExpectedSetPriceFor(int differentBooksCount) => DefaultBookPrice * differentBooksCount * (1 - (differentBooksCount - 1) * DefaultBookDiscount);
    }
}