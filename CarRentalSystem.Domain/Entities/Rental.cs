using CarRentalSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Exceptions.Rental;

namespace CarRentalSystem.Domain.Entities
{
    public class Rental
    {
        public Guid RentalId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid VehicleId { get; private set; }
        public DateTime PickupDate { get; private set; }
        public DateTime ExpectedReturnDate { get; private set; }

        public RentalStatus Status { get; private set; }

        public Rental(Guid customerId, Guid vehicleId, DateTime pickupDate, DateTime expectedReturnDate)
        {
            ValidateDates(pickupDate, expectedReturnDate);

            RentalId = Guid.NewGuid();
            CustomerId = customerId;
            VehicleId = vehicleId;
            PickupDate = pickupDate;
            ExpectedReturnDate = expectedReturnDate;
            Status = RentalStatus.Active;
        }

        private static void ValidateDates(DateTime pickupDate, DateTime expectedReturnDate)
        {
            if (expectedReturnDate <= pickupDate)
            {
                throw new InvalidReturnDateException("Expected return date must be after pickup date.");
            }
        }

        public void UpdateRentalStatus(RentalStatus status)
        {
            if (status != RentalStatus.Active || status != RentalStatus.Completed)
            {
                throw new InvalidUpdateStatus("Invalid update status.");
            }

            Status = status;
        }
    }
}
