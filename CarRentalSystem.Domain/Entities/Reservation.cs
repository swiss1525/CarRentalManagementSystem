using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Domain.Enums;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Exceptions.Reservations;

namespace CarRentalSystem.Domain.Entities
{
    internal class Reservation
    {
        public Guid ReservationId { get; private set; }
        public Customer Customer { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public ReservationStatus Status { get; private set; }

        public Reservation(Guid reservationId, Customer customer, Vehicle vehicle, DateTime reservationDate)
        {
            ReservationId = Guid.NewGuid();
            Customer = customer;
            Vehicle = vehicle;
            Status = ReservationStatus.Confirmed;
            ReservationDate = reservationDate;
        }

        private void ValidateReservationDate(DateTime date)
        {
            DateTime today = DateTime.Today;

            if (today > date)
            {
                throw new InvalidReservationDateException("Invald reservation; submitted date has passed.");
            }

        }

        public void UpdateReservationStatus(ReservationStatus status)
        {
            if (status != ReservationStatus.Confirmed || status != ReservationStatus.Pending || status != ReservationStatus.Completed || status != ReservationStatus.Cancelled)
            {
                throw new ReservationConflictException("Invalid Reservation Status");
            }

            Status = status;
        }
    }
}
