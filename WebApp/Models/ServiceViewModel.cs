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
        public Pet Pet { get; set; }


        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public static ServiceViewModel Parse(Service service)
        {
            return new ServiceViewModel()
            {
                DateCreated = service.DateCreated,
                DateUpdated = service.DateUpdated,
                PetId = service.PetId,
                Pet = service.Pet,
                Products = service.Products,
                EmployeeId = service.EmployeeId,
                Employee = service.Employee,
                Id = service.Id
        };
        }

        public Service ToModel()
        {
            return new Service(Id, DateCreated, DateUpdated, PetId, EmployeeId, Employee, Pet);
        }

        public Service ToModel(Service model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Products = model.Products;
            Pet = model.Pet;
            PetId = model.PetId;
            EmployeeId = model.EmployeeId;
            Employee = model.Employee;
            Id = model.Id;
            return model;
        }

        public bool CompareToModel(Service model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                     Products == model.Products &&
                                 PetId == model.PetId &&
                                 Pet == model.Pet &&
                                 Id == model.Id &&
                                 Employee == model.Employee &&
                                 EmployeeId == model.EmployeeId;
        }
    }
}
