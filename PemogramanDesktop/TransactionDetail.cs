using System;

namespace PemogramanDesktop
{
    public class TransactionDetail
    {
        public Guid TransactionId { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public TransactionDetail(string itemName, int amount, int totalPrice)
        {
            ItemName = itemName;
            Amount = amount;
            TotalPrice = totalPrice;
            Date = DateTime.MinValue;
        }

        public void Update(Guid id, DateTime date)
        {
            TransactionId = id;
            Date = date;
        }
    }
}
