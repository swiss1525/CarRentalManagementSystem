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
        public VehicleCategory Category { get; private set; }
        public double PricePerDay { get; private set; }
        public decimal DailyRate { get; private set; }
        public List<Rental> Rentals { get; private set; } = new();

        public Vehicle(string brand, string model, VehicleCategory category, int yearOfMake, VehicleStatus status, double pricePerDay)
        {
            ValidateBrand(brand);
            ValidateModel(model);
            ValidateYear(yearOfMake);
            ValidatePrice(pricePerDay);
            ValidateCategory(category);
            MarkAsAvailable();

            ID = Guid.NewGuid();
            Brand = brand;
            Model = model;
            Category = category;
            SetDailyRate(category);
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

        private void ValidateCategory(VehicleCategory category)
        {
            if (category != VehicleCategory.Economy && category != VehicleCategory.Sedan && category != VehicleCategory.SUV && category != VehicleCategory.Luxury)
            {
                throw new InvalidVehicleInformationException("Invalid vehicle category.");
            }
        }

        private decimal SetDailyRate(VehicleCategory category)
        {
            decimal dailyRate = 0;
            if (category == VehicleCategory.Luxury)
            {
                dailyRate = 110m;
            }
            if (category == VehicleCategory.SUV)
            {
                dailyRate = 95.5m;
            }
            if (category == VehicleCategory.Sedan)
            {
                dailyRate = 65.5m;
            }
            if (category == VehicleCategory.Economy)
            {
                dailyRate = 50m;
            }
            return dailyRate;
        }

    }
}
