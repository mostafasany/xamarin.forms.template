using System;
using Prism.Mvvm;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class User : BindableBase
    {
        public string Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
    }
}
