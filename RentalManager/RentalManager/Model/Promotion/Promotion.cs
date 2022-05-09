using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManager.Model
{
    public abstract class Promotion
    {
        protected List<Rental> rentals;

        protected DateTime startDate;

        protected DateTime endDate;

        protected decimal creationDiscount;

        protected Promotion()
        {
            this.rentals = new List<Rental>();
        }

        protected Promotion(DateTime startDate, List<Rental> rentals)
        {
            this.startDate = startDate;

            this.rentals = this.ValidateRentals(rentals);
        }

        /// <summary>
        /// Calculates the promotion full price based on its rentals and discount.
        /// </summary>
        public abstract decimal GetPromotionFinalPrice();

        /// <summary>
        /// Validates the rentals to which the promotion will be applied, based on the promotion's specifications.
        /// </summary>
        protected abstract List<Rental> ValidateRentals(List<Rental> rentals);

    }
}
