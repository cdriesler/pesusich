using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Postman.Models
{
    public class Address
    {
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address (string street, string city, string state, string zip)
        {
            AddressLineOne = street;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
