using DataLayer.Base;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class Pet : NamedEntity
    {
        public string Color { get; set; }
        public string Genre { get; set; }

        #region Relationship
        public virtual ICollection<Product> Products { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        #endregion

        public Pet(Guid id, DateTime createdAt, DateTime updatedAt, string name, string color, string genre, Guid clientId) : base(id, createdAt, updatedAt, name)
        {
            Color = color;
            Genre = genre;
            ClientId = clientId;
        }

        public Pet()
        {
        }
    }
}
