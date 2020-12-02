using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Market
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Dealer> Dealers { get; set; }
        public Market(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            Dealers = new List<Dealer>();
        }

        public Dealer GetDealer(string Id)
        {
            return Dealers.Find(x => x.Id == Id);
        }

        public string AddDealer(Dealer dealer)
        {
            if (Dealers.Find(x => x.Id == dealer.Id) != null)
            {
                return $"Dealer with id {dealer.Id} already exists!";
            }
            Dealers.Add(dealer);
            return "Dealer successfully added!";
        }
        public int AddDealers(List<Dealer> dealers)
        {
            int dealersAdded = 0;
            foreach (Dealer dealer in dealers)
            {
                if (Dealers.Find(x => x.Id == dealer.Id) == null)
                {
                    Dealers.Add(dealer);
                    dealersAdded++;
                }
            }
            return dealersAdded;
        }

    }

}
