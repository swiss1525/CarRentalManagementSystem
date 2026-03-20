using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Exceptions.Vehicle
{
    internal class VehicleNotAvailableException : Exception
    {
        public VehicleNotAvailableException(string message) : base(message)
        {
        }
    }
}
