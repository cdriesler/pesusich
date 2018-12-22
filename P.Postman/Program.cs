using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using P.Postman.Models;

namespace P.Postman
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"C:\Users\cdrie\Google Drive\politics\AD57_ED94\flyers\all addresses\semi-sanitized.txt");

            var testMember = DataToMember(data[0] + " " + data[1]);

            Console.WriteLine($"Created member {testMember.Name} from AD{testMember.AssemblyDistrict}/ED{testMember.ElectionDistrict}.");
            Console.WriteLine($"Lives at {testMember.Address.AddressLineOne}.");
            Console.ReadKey();
        }

        static CountyCommitteeMember DataToMember(string data)
        {
            var spaceSplit = data.Split(' ');

            var ad = Convert.ToInt32(spaceSplit[0]);
            var ed = Convert.ToInt32(spaceSplit[1]);
            var gender = spaceSplit[2];

            return null;
        }
    }
}
