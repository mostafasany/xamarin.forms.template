using System;
using Prism.Mvvm;

namespace shellXamarin.Module.Account.Models
{
    public class User : BindableBase
    {
        public string Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }
    }
}
