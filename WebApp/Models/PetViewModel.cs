using System;
using System.Collections.Generic;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class PetViewModel : NamedViewModel
    {
        public string Color { get; set; }
        public string Genre { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }

        public static PetViewModel Parse(Pet pet)
        {
            return new PetViewModel()
            {
                DateCreated = pet.DateCreated,
                DateUpdated = pet.DateUpdated,
                Color = pet.Color,
                Genre = pet.Genre,
                Products = pet.Products,
                Client = pet.Client,
                Name = pet.Name,
                ClientId = pet.ClientId,
                Id = pet.Id,
            };
        }

        public Pet ToModel()
        {
            return new Pet(Id, DateCreated, DateUpdated, Name, Color, Genre, Client, ClientId);
        }

        public Pet ToModel(Pet model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Color = model.Color;
            Genre = model.Genre;
            Products = model.Products;
            Client = model.Client;
            ClientId = model.ClientId;
            Name = model.Name;
            Id = model.Id;
            return model;
        }

        public bool CompareToModel(Pet model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                Color == model.Color &&
                                Genre == model.Genre &&
                                Products == model.Products &&
                                Name == model.Name &&
                                Id == model.Id &&
                                Client == model.Client &&
                                ClientId == model.ClientId;
        }
    }
}
