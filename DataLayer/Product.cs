using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data
{
    public class Product : NamedEntity
    {
        [Required(ErrorMessage = "{0} is required.")]
        public double Price { get; set; }

        #region Relationship
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        #endregion

        public Product(Guid id, DateTime createdAt, DateTime updatedAt, string name, double price, Guid serviceId, Service service) : base(id, createdAt, updatedAt, name)
        {
            Price = price;
            ServiceId = serviceId;
            Service = service;
        }

        public Product()
        {
        }
    }
}
