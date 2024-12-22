using System;
using WebSales.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSales.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Sell { get; set; }


        public SalesRecord()
        {
        }
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller sell)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Sell = sell;
        }
    }
}
