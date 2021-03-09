using Data.Base;
using System;
using System.Collections.Generic;

namespace Data
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

        public Pet(Guid id, DateTime dateCreated, DateTime dateUpted, string name, string color, string genre, Client client, Guid clientId) : base(id, dateCreated, dateUpted, name)
        {
            Color = color;
            Genre = genre;
            Client = client;
            ClientId = clientId;
        }

        public Pet()
        {
        }
    }
}
