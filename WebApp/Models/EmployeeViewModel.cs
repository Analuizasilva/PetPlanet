using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class EmployeeViewModel : NamedViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int TaxNumber { get; set; }

        [ForeignKey("Store")]
        public Guid StoreId { get; set; }
        public Store Store { get; set; }

    public static EmployeeViewModel Parse(Employee employee)
        {
            return new EmployeeViewModel()
            {
                DateCreated = employee.DateCreated,
                DateUpdated = employee.DateUpdated,
                Position = employee.Position,
                Identification = employee.Identification,
                TaxNumber = employee.TaxNumber,
                StoreId = employee.StoreId,
                Store = employee.Store,
                Name = employee.Name,
                Id = employee.Id
            };
        }

        public Employee ToModel()
        {
            return new Employee(Id, DateCreated, DateUpdated, Name, Position, Identification, TaxNumber, StoreId);
        }

        public Employee ToModel(Employee model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Position = model.Position;
            Identification = model.Identification;
            TaxNumber = model.TaxNumber;
            StoreId = model.StoreId;
            Store = model.Store;
            Name = model.Name;
            Id = model.Id;            
            return model;
        }

        public bool CompareToModel(Employee model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                 Position == model.Position &&
                                 Identification == model.Identification &&
                                 TaxNumber == model.TaxNumber &&
                                  Name == model.Name &&
                                  Id == model.Id &&
                                  Store == model.Store &&
                                 StoreId == model.StoreId;
        }
    }
}

