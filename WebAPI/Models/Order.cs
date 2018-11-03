using Core.Interfaces.Models;
using System;

namespace WebAPI.Models
{
    public class Order : IOrder
    {
        public string OrderNumber { get; set; }
        public int Quantity { get; set; }
        public string CustomerId { get; set; }
        public string Id { get; set; }
        public string GUId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}