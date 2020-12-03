using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [TestFixture]
    public class MarketTests
    {
        Market market;
        Dealer dealer1;
        Dealer dealer2;
        Dealer dealer3;

        [SetUp]
        public void Setup()
        {
            market = new Market("M1", "Parc Auto Somcuta");
            dealer1 = new Dealer("D1", "Samsaru2020");
            dealer2 = new Dealer("D2", "Granny Cars");
            dealer3 = new Dealer("D3", "Cazane SRL");

            dealer1.AddCar(new Car(
                "AAA000",
                "Dacia",
                "Sandero",
                DateTime.Now.AddDays(-2),
                5,
                12000,
                true
             ));
            dealer1.AddCar(new Car(
                "AAA001",
                "Dacia",
                "Logan",
                DateTime.Now.AddDays(-4),
                5,
                9000,
                true
             ));
            dealer1.AddCar(new Car(
                "AAA002",
                "BMW",
                "X5",
                DateTime.Now.AddMonths(-1),
                7,
                29000,
                true
             ));
            dealer1.AddCar(new Car(
                "AAA003",
                "Audi",
                "Q8",
                DateTime.Now,
                5,
                69000,
                false
            ));
            dealer1.AddCar(new Car(
                "AAA004",
                "Skoda",
                "Superb",
                DateTime.Now.AddMonths(-3),
                7,
                32000,
                false
            ));
            dealer1.AddCar(new Car(
                 "AAA005",
                 "VolksWagen",
                 "Golf 7",
                 DateTime.Now.AddMonths(-2),
                 10,
                 25000,
                 true
             ));
            dealer1.AddCar(new Car(
                 "AAA006",
                 "Ford",
                 "F150",
                 DateTime.Now.AddMonths(-5),
                 4,
                 65000,
                 true
             ));

            dealer2.AddCar(new Car(
               "AAA007",
               "Opel",
               "Corsa",
               DateTime.Now.AddMonths(-1),
               1,
               11000,
               false
           ));
            dealer2.AddCar(new Car(
             "AAA008",
             "Renault",
             "Megane 4",
             DateTime.Now.AddMonths(-2),
             1,
             11000,
             true
         ));

            dealer3.AddCar(new Car(
               "AAA009",
               "Trabant",
               "N/A",
               DateTime.Now.AddYears(-40),
               0,
               4000,
               true
           ));
            dealer3.AddCar(new Car(
               "AAA010",
               "Chevrolet",
               "Impala",
               DateTime.Now.AddYears(-50),
               0,
               24000,
               true
           ));
            market.Dealers = new List<Dealer> { dealer1, dealer2, dealer3 };
        }

        [Test]
        public void Test_GetDealer()
        {
            Dealer requestedDealer = market.GetDealer("D1");
            Assert.IsTrue(requestedDealer == market.Dealers[0]);
        }

        [Test]
        public void Test_GetNonExistingDealer()
        {
            Assert.IsNull(market.GetDealer("D10"));
        }

        [Test]
        public void Test_AddDealer()
        {
            Dealer newDealer = new Dealer("D4", "Test Add Dealer");
            Assert.AreEqual(market.AddDealer(newDealer), "Dealer successfully added!");
        }

        [Test]
        public void Test_AddExistingDealer()
        {
            Dealer newDealer = new Dealer("D3", "Test Add Dealer");
            Assert.AreEqual(market.AddDealer(newDealer), "Dealer with id D3 already exists!");
        }

        [Test]
        public void Test_AddDealers()
        {
            Dealer dealerTest2 = new Dealer("D4", "Test Add Dealer");
            Dealer dealerTest3 = new Dealer("D5", "Test Add Dealer");
            Assert.AreEqual(market.AddDealers(new List<Dealer> { dealer1, dealerTest2, dealerTest3 }), 2);
        }

        [Test]
        public void Test_RemoveDealer()
        {
            Assert.IsTrue(market.RemoveDealer("D2"));
        }
        [Test]
        public void Test_RemoveNonExistentDealer()
        {
            Assert.IsFalse(market.RemoveDealer("D92"));
        }
    }
}
