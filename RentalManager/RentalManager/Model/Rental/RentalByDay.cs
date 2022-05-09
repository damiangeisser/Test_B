using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManager.Model
{
    public class RentalByDay : Rental
    {
        private static decimal rate = 20;

        public RentalByDay(DateTime creationDate, int duration): base (creationDate, duration)
        {
            this.creationRate = rate;
        }

        public decimal GetCurrentRate()
        {
            return RentalByDay.rate;
        }

        /// <summary>
        /// Validates that the amount of days is greater than 0 and less than a week.
        /// </summary>
        protected override int ValidateRentalTerm(int days)
        {
            if (days < 1)
            {
                return 1;
            }
            else if(days > 6)
            {
                return 6;
            }

            return days;
        }

        /// <summary>
        /// Generates a string containing the rental term detail.
        /// </summary>
        public override string GetRentalTermDetails()
        {
            string rentalTerm = this.RentalTerm.ToString();

            string rentalStartingDate = this.GetCreationDate().ToString("yyyy/MM/dd HH:mm");

            return "The rental term is: " + rentalTerm + (this.RentalTerm > 1 ? " days." : " day.") + "Starting from: " + rentalStartingDate + " ";
        }
    }
}
