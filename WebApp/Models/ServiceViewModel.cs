using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class ServiceViewModel : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        [ForeignKey("Pet")]
        public Guid PetId { get; set; }

        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }

        public static ServiceViewModel Parse(Service service)
        {
            return new ServiceViewModel()
            {
                DateCreated = service.DateCreated,
                DateUpdated = service.DateUpdated,
                PetId = service.PetId,
                Products = service.Products,
                EmployeeId = service.EmployeeId,
                Id = service.Id
        };
        }

        public Service ToModel()
        {
            return new Service(Id, DateCreated, DateUpdated, PetId, EmployeeId);
        }

        public Service ToModel(Service model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Products = model.Products;
            PetId = model.PetId;
            EmployeeId = model.EmployeeId;            
            Id = model.Id;
            return model;
        }

        public bool CompareToModel(Service model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                     Products == model.Products &&
                                 PetId == model.PetId &&                                
                                 Id == model.Id &&
                                 EmployeeId == model.EmployeeId;
        }
    }
}
