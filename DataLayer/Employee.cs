using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Base;

namespace DataLayer
{
    public class Employee : NamedEntity
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int TaxNumber { get; set; }

        #region Relationship
        [ForeignKey("Store")]
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        #endregion

        public Employee(Guid id, DateTime createdAt, DateTime updatedAt, string name, string position, string identification, int taxNumber, Guid storeId) : base(id, createdAt, updatedAt, name)
        {
            Position = position;
            Identification = identification;
            TaxNumber = taxNumber;
            StoreId = storeId;
        }

        public Employee()
        {
        }
    }
}
