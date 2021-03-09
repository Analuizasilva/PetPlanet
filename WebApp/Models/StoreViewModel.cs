using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class StoreViewModel : NamedViewModel
    {      

        [Required(ErrorMessage = "{0} is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int TaxNumber { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Pet> Pets { get; set; }

        public static StoreViewModel Parse(Store store)
        {
            return new StoreViewModel()
            {
                DateCreated = store.DateCreated,
                DateUpdated = store.DateUpdated,
                PhoneNumber = store.PhoneNumber,
                Address = store.Address,
                TaxNumber = store.TaxNumber,
                Employees = store.Employees,
                Pets = store.Pets
            };
        }

        public Store ToModel()
        {
            return new Store(Id, DateCreated, DateUpdated, Address, PhoneNumber, TaxNumber, Name);
        }

        public Store ToModel(Store model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            PhoneNumber = model.PhoneNumber;
            Address = model.Address;
            TaxNumber = model.TaxNumber;
            Pets = model.Pets;
            Employees = model.Employees;
            return model;
        }

        public bool CompareToModel(Store model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                 PhoneNumber == model.PhoneNumber &&
                                 Address == model.Address &&
                                 TaxNumber == model.TaxNumber &&
                                 Employees == model.Employees &&
                                 Pets == model.Pets;
        }
    }
}
