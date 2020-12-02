using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Dealer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public Dealer(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            Cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            if (Cars.IndexOf(car) < 0)
            {
                Cars.Add(car);
            }
        }

        public void RemoveCar(string vin)
        {
            int index = Cars.FindIndex(x => x.Vin == vin);
            if (index > 0)
            {
                Cars.RemoveAt(index);
            }
        }

        public Car GetCar(string vin)
        {
            Car car = Cars.Find(x => x.Vin == vin);
            if (car != null)
            {
                return car;
            }
            return null;
        }

        public List<Car> GetAvailableCars()
        {
            return Cars.FindAll(x => x.IsAvailable == true);
        }

        public int GetNrOfCarsWithMinGuaranty(int guaranty)
        {
            List<Car> cars = Cars.FindAll(x => x.Guaranty >= guaranty);
            return (cars != null && cars.Count > 0) ? cars.Count : 0;
        }

        public double GetTotalValue(DateTime? onlyBeforeFabDate = null)
        {
            double totalValue = 0;
            foreach (Car car in Cars)
            {
                if (onlyBeforeFabDate != null)
                {
                    if (car.FabDate < onlyBeforeFabDate)
                    {
                        totalValue += car.Price;
                    }
                }
                else
                {
                    totalValue += car.Price;
                }
            }
            return totalValue;
        }
    }
}
