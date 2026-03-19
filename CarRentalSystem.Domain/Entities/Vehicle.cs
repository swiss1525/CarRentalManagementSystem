using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Entities
{
    public class Vehicle
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public Guid ID { get; private set; }
        public int YearOfMake { get; private set; }
        public bool IsAvailable { get; private set; }
        public double PricePerDay { get; private set; }

        public Vehicle(string brand, string model, Guid id, int yearOfMake, bool isAvailable, double pricePerDay)
        {

        }

    }
}
