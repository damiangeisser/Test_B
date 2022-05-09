using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManager.Model
{
    public abstract class Rental
    {
        protected DateTime creationDate;

        protected decimal creationRate;

        protected Rental(DateTime creationDate, int rentalTerm)
        {
            this.creationDate = creationDate;

            this.RentalTerm = this.ValidateRentalTerm(rentalTerm);
        }

        public int RentalTerm { get; set;}

        /// <summary>
        /// Returns the apliable rate when the rental was created.
        /// </summary>
        public decimal GetRate()
        {
            return this.creationRate;
        }

        /// <summary>
        /// Returns the rental initial date.
        /// </summary>
        public DateTime GetCreationDate()
        {
            return this.creationDate;
        }

        /// <summary>
        /// Calculates the rental full price based on its duration.
        /// </summary>
        public decimal GetFullPrice()
        {
            decimal rate = this.GetRate();

            return this.RentalTerm * rate;
        }

        /// <summary>
        /// Generates a string containing the rental full price detail.
        /// </summary>
        public string GetRentalPriceDetails()
        {
            string rentalFullPrice = Math.Round(this.GetFullPrice(), 2).ToString();

            return "The rental full price is: $" + rentalFullPrice;
        }

        /// <summary>
        /// Generates a string containing the rental term and full price detail.
        /// </summary>
        public string GetRentalDetails()
        {
            return this.GetRentalTermDetails() + this.GetRentalPriceDetails();
        }

        /// <summary>
        /// Validates that the argument is a plausible duration for the rental type.
        /// </summary>
        protected abstract int ValidateRentalTerm(int rentalTerm);


        /// <summary>
        /// Generates a string containing the rental term detail.
        /// </summary>
        public abstract string GetRentalTermDetails();
    }
}
