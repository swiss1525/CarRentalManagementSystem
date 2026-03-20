using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Exceptions.Vehicle
{
    internal class InvalidVehicleInformationException : Exception
    {
        public InvalidVehicleInformationException()
            : base("Invalid vehicle information.")
        {
        }

        public InvalidVehicleInformationException(string message) : base(message)
        {
        }
    }
}
