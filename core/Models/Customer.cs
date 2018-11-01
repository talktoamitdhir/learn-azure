using Core.Interfaces.Models;
using System;

namespace Core.Models
{
    public class Customer : ICustomer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
        public string GUId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
