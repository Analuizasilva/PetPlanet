using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Base
{
    public class NamedViewModel : BaseViewModel
    {     
        [Required(ErrorMessage = "Insert the name")]
        public string Name { get; set; }
    }
}
