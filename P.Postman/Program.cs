﻿using System;
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

            var members = new List<CountyCommitteeMember>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Length < 8 || data[i].Contains('/')) continue;

                members.Add(DataToMember(data[i] + " " + data[i + 1]));
            }

            var ad57members = members.Where(x => x.AssemblyDistrict == 57);

            if (File.Exists(@"C:\Users\cdrie\Google Drive\politics\AD57_ED94\flyers\all addresses\output.txt")) File.Delete(@"C:\Users\cdrie\Google Drive\politics\AD57_ED94\flyers\all addresses\output.txt");

            foreach (var mem in ad57members)
            {
                var profile = new List<string>()
                {
                    mem.Name,
                    mem.Address.AddressLineOne,
                    $"Brooklyn, NY {mem.Address.Zip}"
                };

                File.AppendAllLines(@"C:\Users\cdrie\Google Drive\politics\AD57_ED94\flyers\all addresses\output.txt", profile);
            }

            //Console.WriteLine($"Created member {testMember.Name} from AD{testMember.AssemblyDistrict}/ED{testMember.ElectionDistrict}.");
            //Console.WriteLine($"Lives at {testMember.Address.AddressLineOne} in Brooklyn, NY {testMember.Address.Zip}");

            Console.WriteLine(ad57members.Count());
            Console.ReadKey();
        }

        static CountyCommitteeMember DataToMember(string data)
        {
            var spaceSplit = data.Split(' ');

            var ad = Convert.ToInt32(spaceSplit[0]);
            var ed = Convert.ToInt32(spaceSplit[1]);
            var gender = spaceSplit[2];

            var genderSplit = data.Split(new string[] { gender + " " }, 2, StringSplitOptions.None);

            var addressIndex = genderSplit[1].IndexOfAny("0123456789".ToCharArray());

            var name = genderSplit[1].Substring(0, addressIndex - 1);

            var fullAddress = genderSplit[1].Substring(addressIndex);
            var addressInfo = fullAddress.Replace(" Brooklyn, NY ", "$").Split('$');

            var address = new Address(addressInfo[0], "Brooklyn", "NY", addressInfo[1]);

            var member = new CountyCommitteeMember(ad, ed, gender, name, address);

            Console.WriteLine($"Created member {member.Name} from AD{member.AssemblyDistrict}/ED{member.ElectionDistrict}.");

            return member;
        }
    }
}
