using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Exceptions.Customer
{
    internal class InvalidDriverLicenseException : Exception
    {
        public InvalidDriverLicenseException() : base("Invalid Driver License.")
        {

        }
    }
}
