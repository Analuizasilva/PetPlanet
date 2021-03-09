using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data
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

        public Service(Guid id, DateTime dateCreated, DateTime dateUpdated, Guid petId, Guid employeeId) : base(id, dateCreated, dateUpdated)
        {
            PetId = petId;
            EmployeeId = employeeId;
        }

        public Service()
        {
        }
    }
}
