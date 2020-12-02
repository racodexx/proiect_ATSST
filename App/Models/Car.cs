using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Car
    {
        public string Vin { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime FabDate { get; set; }
        public int Guaranty { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }

        public Car(string Vin, string Brand, string Model, DateTime FabDate, int Guaranty, int Price, bool IsAvailable)
        {
            this.Vin = Vin;
            this.Brand = Brand;
            this.Model = Model;
            this.FabDate = FabDate;
            this.Guaranty = Guaranty;
            this.Price = Price;
            this.IsAvailable = IsAvailable;
        }
    }
}
