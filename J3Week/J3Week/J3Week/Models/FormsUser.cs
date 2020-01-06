using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace J3Week.Models
{
    public class FormsUser: IMultiSelectModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
