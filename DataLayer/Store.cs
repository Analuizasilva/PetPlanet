using DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Store : NamedEntity
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int TaxNumber { get; set; }

        #region Relationship
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        #endregion

        public Store(Guid id, DateTime createdAt, DateTime updatedAt, string address, int phoneNumber, int taxNumber, string name) : base(id, createdAt, updatedAt, name)
        {
            Address = address;
            PhoneNumber = phoneNumber;
            TaxNumber = taxNumber;
        }

        public Store()
        {
        }
    }
}
