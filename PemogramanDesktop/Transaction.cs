using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemogramanDesktop
{
    internal class Transaction
    {
        public Guid Id { get; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public Transaction(int totalPrice)
        {
            Id = Guid.NewGuid();
            TotalPrice = totalPrice;
            Date = DateTime.MinValue;
        }

        public void UpdateDate(DateTime date)
        {
            Date = date;
        }
    }
}
