using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [TestFixture]
    public class DealerTests
    {
        Dealer dealer;

        [SetUp]
        public void Setup()
        {
            dealer = new Dealer("D1", "Samsaru2020");
            dealer.AddCar(new Car(
                "AAA000",
                "Dacia",
                "Sandero",
                DateTime.Now.AddDays(-2),
                5,
                12000,
                true
             ));
            dealer.AddCar(new Car(
                "AAA001",
                "Dacia",
                "Logan",
                DateTime.Now.AddDays(-4),
                5,
                9000,
                true
             ));
            dealer.AddCar(new Car(
                "AAA002",
                "BMW",
                "X5",
                DateTime.Now.AddMonths(-1),
                7,
                29000,
                true
             ));
            dealer.AddCar(new Car(
                "AAA003",
                "Audi",
                "Q8",
                DateTime.Now,
                5,
                69000,
                false
            ));
            dealer.AddCar(new Car(
                "AAA004",
                "Skoda",
                "Superb",
                DateTime.Now.AddMonths(-3),
                7,
                32000,
                false
            ));
            dealer.AddCar(new Car(
                 "AAA005",
                 "VolksWagen",
                 "Golf 7",
                 DateTime.Now.AddMonths(-2),
                 10,
                 25000,
                 true
             ));
            dealer.AddCar(new Car(
                 "AAA006",
                 "Ford",
                 "F150",
                 DateTime.Now.AddMonths(-5),
                 4,
                 65000,
                 true
             ));
        }

        [Test]
        public void Test_GetCar()
        {
            Car requestedCar = dealer.GetCar("AAA000");
            Assert.IsTrue(requestedCar == dealer.Cars[0]);
        }

        [Test]
        public void Test_GetNonExistingCar()
        {
            Car requestedCar = dealer.GetCar("ZZZ000");
            Assert.IsNull(requestedCar);
        }

        [Test]
        public void Test_AddCar()
        {
            int initialCarsCount = dealer.Cars.Count;
            Car newCar = new Car(
                 "AAA007",
                "BMW",
                "X1",
                DateTime.Now,
                4,
                25000,
                true
                );
            dealer.AddCar(newCar);
            Assert.IsTrue(dealer.Cars.Count == initialCarsCount + 1 && dealer.Cars[initialCarsCount] == newCar);
        }

        [Test]
        public void Test_RemoveCar()
        {
            int initialCarsCount = dealer.Cars.Count;
            dealer.RemoveCar("AAA001");
            Assert.IsTrue(dealer.Cars.Count == initialCarsCount - 1 && dealer.GetCar("AAA001") == null);
        }

        [Test]
        public void Test_GetAvailableCars()
        {
            Assert.IsTrue(dealer.GetAvailableCars().Count == 5);
        }

        [Test]
        public void Test_GetNrOfCarsWithMinGuaranty()
        {
            Assert.IsTrue(dealer.GetNrOfCarsWithMinGuaranty(7) == 3);
        }

        [Test]
        public void Test_GetTotalValue()
        {
            Assert.IsTrue(dealer.GetTotalValue() == 241000);
        }
    }
}
