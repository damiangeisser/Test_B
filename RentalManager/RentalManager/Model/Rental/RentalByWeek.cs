using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManager.Model
{
    public class RentalByWeek : Rental
    {
        private static decimal rate = 60;

        public RentalByWeek(DateTime creationDate, int duration): base(creationDate, duration)
        {
            this.creationRate = rate;
        }

        public decimal GetCurrentRate()
        {
            return RentalByWeek.rate;
        }

        /// <summary>
        /// Validates that the amount of weeks is greater than 0.
        /// </summary>
        protected override int ValidateRentalTerm(int weeks)
        {
            if (weeks < 1)
            {
                return 1;
            }

            return weeks;
        }

        /// <summary>
        /// Generates a string containing the rental term detail.
        /// </summary>
        public override string GetRentalTermDetails()
        {
            string rentalTerm = this.RentalTerm.ToString();

            string rentalStartingDate = this.GetCreationDate().ToString("yyyy/MM/dd HH:mm");

            return "The rental term is: " + rentalTerm + (this.RentalTerm > 1 ? " weeks." : " week.") + "Starting from: " + rentalStartingDate + " ";       
        }
    }
}
