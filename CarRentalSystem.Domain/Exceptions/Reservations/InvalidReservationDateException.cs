using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Exceptions.Reservations
{
    public class InvalidReservationDateException : Exception
    {
        public InvalidReservationDateException(string message) :base(message) { }
    }
}
