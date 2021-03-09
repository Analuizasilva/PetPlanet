using System;

namespace WebApp.Models.Base
{
    public class BaseViewModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid Id { get; set; }
    }
}
