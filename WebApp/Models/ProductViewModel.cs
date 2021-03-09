using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class ProductViewModel : NamedViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        public double Price { get; set; }

        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }

        public static ProductViewModel Parse(Product product)
        {
            return new ProductViewModel()
            {
                DateCreated = product.DateCreated,
                DateUpdated = product.DateUpdated,
                Price = product.Price,
                ServiceId = product.ServiceId,
            };
        }

        public Product ToModel()
        {
            return new Product(Id, DateCreated, DateUpdated, Name, Price, ServiceId);
        }

        public Product ToModel(Product model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Price = model.Price;
            ServiceId = model.ServiceId;
            return model;
        }

        public bool CompareToModel(Product model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                 Price == model.Price &&
                                 ServiceId == model.ServiceId;
        }
    }
}
