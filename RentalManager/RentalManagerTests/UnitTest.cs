using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalManager.Model;
using System;
using System.Collections.Generic;

namespace RentalManagerTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetFullPriceHourTest()
        {
            //arrange
            RentalByHour rentalByHour = new RentalByHour(DateTime.Now, 10);

            //act
            decimal rentalFullPrice = rentalByHour.GetFullPrice();

            //assert
            Assert.AreEqual(50, rentalFullPrice);
        }

        [TestMethod]
        public void GetFullPriceDayTest()
        {
            //arrange
            RentalByDay rentalByDay = new RentalByDay(DateTime.Now, 10);

            //act
            decimal rentalFullPrice = rentalByDay.GetFullPrice();

            //assert
            Assert.AreEqual(120, rentalFullPrice);
        }

        [TestMethod]
        public void GetFullPriceDayWeek()
        {
            //arrange
            RentalByWeek rentalByWeek = new RentalByWeek(DateTime.Now, -5);

            //act
            decimal rentalFullPrice = rentalByWeek.GetFullPrice();

            //assert
            Assert.AreEqual(60, rentalFullPrice);
        }

        [TestMethod]
        public void GetFamilyRentalFinalPrice()
        {
            //arrange
           
            List<Rental> rentals = new List<Rental>();

            rentals.Add(new RentalByHour(DateTime.Now, 10));

            rentals.Add(new RentalByDay(DateTime.Now, 10));

            rentals.Add(new RentalByWeek(DateTime.Now, -5));

            FamilyRental promotion = new FamilyRental(DateTime.Now, rentals);

            //act
            decimal promotionFinalPrice = promotion.GetPromotionFinalPrice();

            //assert
            Assert.AreEqual(161, promotionFinalPrice);
        }


    }
}