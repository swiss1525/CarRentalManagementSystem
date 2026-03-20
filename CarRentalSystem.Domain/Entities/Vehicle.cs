using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Enums;

using CarRentalSystem.Domain.Exceptions.Vehicle;

namespace CarRentalSystem.Domain.Entities
{
    public class Vehicle
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public Guid ID { get; private set; }
        public int YearOfMake { get; private set; }
        public VehicleStatus Status { get; private set; }
        public double PricePerDay { get; private set; }
        public List<Rental> Rentals { get; private set; }

        public Vehicle(string brand, string model, int yearOfMake, VehicleStatus status, double pricePerDay)
        {
            ValidateBrand(brand);
            ValidateModel(model);
            ValidateYear(yearOfMake);
            ValidatePrice(pricePerDay);
            MarkAsAvailable();

            Brand = brand;
            Model = model;
            ID = Guid.NewGuid();
            YearOfMake = yearOfMake;
            PricePerDay = pricePerDay;
        }

        public void MarkAsAvailable()
        {
            Status = VehicleStatus.Available;
        }

        public void MarkAsReserved()
        {
            if (Status != VehicleStatus.Available)
            {
                throw new VehicleNotAvailableException("Vehicle is not available at the moment.");
            }
            Status = VehicleStatus.Reserved;
        }

        public void SendToMaintenance()
        {
            Status = VehicleStatus.Maintenance;
        }

        public void UpdatePricePerDay(double newPrice)
        {
            ValidatePrice(newPrice);
            PricePerDay = newPrice;
        }

        private void ValidateBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new InvalidVehicleInformationException("Brand cannot be empty.");
        }

        private void ValidateModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new InvalidVehicleInformationException("Model cannot be empty.");
        }

        private void ValidateYear(int year)
        {
            if (year < 1886 || year > DateTime.Now.Year + 1)
                throw new InvalidVehicleInformationException("Year of make is invalid.");
        }

        private void ValidatePrice(double price)
        {
            if (price <= 0)
                throw new InvalidVehicleInformationException("Price per day must be greater than 0.");
        }

    }
}
