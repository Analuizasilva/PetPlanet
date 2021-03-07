using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataLayer.Base;

namespace DataLayer
{
    public class Client : NamedEntity
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Identification { get; set; }

        #region Relationship
        public virtual ICollection<Pet> Pets { get; set; }

        #endregion

        public Client()
        {

        }
        public Client(Guid id, DateTime createdAt, DateTime updatedAt, string name, int phoneNumber, string identification) : base(id, createdAt, updatedAt, name)
        {
            PhoneNumber = phoneNumber;
            Identification = identification;
        }
    }
}
