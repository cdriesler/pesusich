using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Postman.Models
{
    public class CountyCommitteeMember
    {
        public int AssemblyDistrict { get; set; }
        public int ElectionDistrict { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public CountyCommitteeMember(int ad, int ed, string gender, string name, Address address)
        {
            AssemblyDistrict = ad;
            ElectionDistrict = ed;
            Gender = gender;
            Name = name;
            Address = address;
        }
    }
}
