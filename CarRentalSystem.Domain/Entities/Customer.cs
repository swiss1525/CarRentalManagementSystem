using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Domain.Exceptions.Customer;

namespace CarRentalSystem.Domain.Entities
{
    public class Customer
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public Guid CustomerId { get; private set; }
        public string DriverLicense { get; private set; }
        public List<Rental> Rentals { get; private set; } = new();

        public Customer(string name, DateTime dateOfBirth, string email, string driverLicense)
        {
            ValidateName(name);
            ValidateAge(age);
            ValidateEmail(email);
            ValidateDriverLicense(driverLicense);

            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            CustomerId = Guid.NewGuid();
            DriverLicense = driverLicense;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidInformationException("Name can not be empty");
            }
        }

        private static void ValidateAge(DateTime dob)
        {
            var today = DateTime.UtcNow;

            int age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age < 18)
            {
                throw new UnderageCustomerException("Customer is underage.");
            }
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidInformationException("Email can not be empty");
            }
        }

        private void ValidateDriverLicense(string driverLicense)
        {
            if (string.IsNullOrWhiteSpace(driverLicense))
            {
                throw new InvalidInformationException("Driver license can not be empty");
            }
        }

        public void UpdateName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            ValidateEmail(email);
            Email = email;
        }

        public void UpdateDriverLicense(string driverLicense)
        {
            ValidateDriverLicense(driverLicense);
            DriverLicense = driverLicense;
        }
    }
}
