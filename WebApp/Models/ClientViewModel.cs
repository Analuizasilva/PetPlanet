using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data;
using WebApp.Models.Base;

namespace WebApp.Models
{
    public class ClientViewModel : NamedViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Identification { get; set; }

        public IEnumerable<Pet> Pets { get; set; }


        public static ClientViewModel Parse(Client client)
        {
            return new ClientViewModel()
            {
                DateCreated = client.DateCreated,
                DateUpdated = client.DateUpdated,
                PhoneNumber = client.PhoneNumber,
                Identification = client.Identification,
                Pets = client.Pets

            };
        }

        public Client ToModel()
        {
            return new Client(Id, DateCreated, DateUpdated, Name, PhoneNumber, Identification);
        }

        public Client ToModel(Client model)
        {
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            PhoneNumber = model.PhoneNumber;
            Identification = model.Identification;
            Pets = model.Pets;
            return model;
        }

        public bool CompareToModel(Client model)
        {
            return DateCreated == model.DateCreated &&
                     DateUpdated == model.DateUpdated &&
                                 PhoneNumber == model.PhoneNumber &&
                                 Identification == model.Identification &&
                                  Pets == model.Pets;
        }
    }
}

