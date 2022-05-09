using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManager.Model
{
    public class RentalByHour : Rental
    {
        private static decimal rate = 5;

        public RentalByHour(DateTime creationDate, int rentalTerm) : base(creationDate, rentalTerm)
        { 
            this.creationRate = rate;
        }

        public decimal GetCurrentRate()
        {
            return RentalByHour.rate;
        }

        /// <summary>
        /// Validates that the amount of hours is greater than 0 and less than a day.
        /// </summary>
        protected override int ValidateRentalTerm(int hours)
        {
            if (hours < 1)
            {
                return 1;
            }
            else if (hours > 24)
            {
                return 24;
            }

            return hours;
        }

        /// <summary>
        /// Generates a string containing the rental term detail.
        /// </summary>
        public override string GetRentalTermDetails()
        {
            string rentalTerm = this.RentalTerm.ToString();

            string rentalStartingDate = this.GetCreationDate().ToString("yyyy/MM/dd HH:mm");
 
            return "The rental term is: " + rentalTerm + (this.RentalTerm > 1 ? " hours. " : " hour. ") + "Starting from: " + rentalStartingDate + " ";
        }
    }

}
