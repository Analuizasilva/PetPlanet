using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class PetViewModel : NamedViewModel
    {
        public string Color { get; set; }
        public string Genre { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

        [ForeignKey("Client")]
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
                ClientId = pet.ClientId
            };
        }

        public Pet ToModel()
        {
            return new Pet(Id, DateCreated, DateUpdated, Name, Color, Genre, ClientId);
        }

        public Pet ToModel(Pet model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Color = model.Color;
            Genre = model.Genre;
            Products = model.Products;
            ClientId = model.ClientId;
            return model;
        }

        public bool CompareToModel(Pet model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                 Color == model.Color &&
                                 Genre == model.Genre &&
                                  Products == model.Products &&
                                  ClientId == model.ClientId;
        }
    }
}
