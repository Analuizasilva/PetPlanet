﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; protected set; }

        protected virtual void RegisterChange()
        {
            DateUpdated = DateTime.UtcNow;
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
            DateUpdated = DateTime.UtcNow;
            DateCreated = DateTime.UtcNow;
        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAd)
        {
            Id = id;
            DateCreated = createdAt;
            DateUpdated = updatedAd;
        }
    }
}
