using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Base;

namespace DataLayer
{
    public class Service : Entity
    {
        #region Relationship
        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("Pet")]
        public Guid PetId { get; set; }
        public Pet Pet { get; set; }

        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        #endregion

        public Service(Guid id, DateTime createdAt, DateTime updatedAt, Guid petId, Guid employeeId) : base(id, createdAt, updatedAt)
        {
            PetId = petId;
            EmployeeId = employeeId;
        }
    }
}
