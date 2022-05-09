using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManager.Model
{
    public class FamilyRental : Promotion
    {
        private static decimal discount = 30;

        public FamilyRental(DateTime startDate, List<Rental> rentals) : base(startDate, rentals)
        {
            this.creationDiscount = FamilyRental.discount;
        }

        public decimal GetDiscount()
        {
            return this.creationDiscount;
        }

        /// <summary>
        /// Validates that amount of rentals is between 3 and 5.
        /// </summary>
        protected override List<Rental> ValidateRentals(List<Rental> rentals)
        {
            if(rentals != null && rentals.Count >= 3 && rentals.Count <= 5 )
            {
                return rentals;
            }
            else
            {
                throw new ArgumentException("Invalid rentals amount");
            }
        }

        /// <summary>
        /// Calculates the promotion full price based on its rentals and discount.
        /// </summary>
        public override decimal GetPromotionFinalPrice()
        {
            decimal rentalsFullPrice = this.rentals.Sum(r => r.GetFullPrice());

            decimal discount = this.GetDiscount();

            decimal discountFactor = 1 - discount / 100;

            return Math.Round(rentalsFullPrice * discountFactor, 2);
        }
    }
}


