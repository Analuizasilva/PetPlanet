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

        public static EmployeeViewModel Parse(Employee employeeduct)
        {
            return new EmployeeViewModel()
            {
                DateCreated = employeeduct.DateCreated,
                DateUpdated = employeeduct.DateUpdated,
                Position = employeeduct.Position,
                Identification = employeeduct.Identification,
                TaxNumber = employeeduct.TaxNumber,
                StoreId = employeeduct.StoreId,
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
            return model;
        }

        public bool CompareToModel(Employee model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                 Position == model.Position &&
                                 Identification == model.Identification &&
                                 TaxNumber == model.TaxNumber &&
                                 StoreId == model.StoreId;
        }
    }
}

