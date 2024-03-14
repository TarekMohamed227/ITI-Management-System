using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_beta3
{
    public class Admin : Person
    {
        public static int Adminidentifer = 1;
        public static string FileName = @"D:\oop beta3\admins.json";
        public Admin(int id, string name, string adress, string phone, string role)
            : base(id, name, adress, phone, role)
        {

        }

        public static int GetId()
        {
            var admins = ReadAdminFromFile(FileName);
            if (admins.Count == 0)
            {
                return 1;
            }
            else
            {
                return admins[admins.Count - 1].Id + 1;
            }
        }

        public static List<Admin> ReadAdminFromFile(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<Admin>();
            }
            return JsonConvert.DeserializeObject<List<Admin>>(jsonString);
        }
        public static void AddAdminToFile(Admin admin, string fileName)
        {
            List<Admin> admins = ReadAdminFromFile(fileName);

            File.WriteAllText(fileName, "[]");
            if (admins.Count != 0)
            {
                bool flag = false;
                for (int i = 0; i < admins.Count; i++)
                {
                    if (admins[i].Name == admin.Name && admins[i].PhoneNumber == admin.PhoneNumber
                    && admins[i].Address == admin.Address)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    admins.Add(admin);
                    SaveAdminToFile(admins, fileName);
                }
                else if (flag == true)
                {
                    SaveAdminToFile(admins, fileName);
                }
            }
            else
            {
                admins.Add(admin);
                SaveAdminToFile(admins, fileName);
            }

            var credential = new Credential(admin.Id, admin.Name + "Login", $"{admin.Id}Pass");
            Credential.UpdateCredential(credential);
        }
        public static void RemoveAdminToFile(int id, string fileName)
        {
            List<Admin> admins = ReadAdminFromFile(fileName);

            File.WriteAllText(fileName, "[]");

            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].Id == id)
                {
                    admins.RemoveAt(i);
                }
            }

            var credentioalstring = File.ReadAllText(Credential.FileName);
            var credentials = JsonConvert.DeserializeObject<List<Credential>>(credentioalstring);
            File.WriteAllText(Credential.FileName, "[]");
            credentials.RemoveAll(c => c.PersonId == id);
            var credentialstring = JsonConvert.SerializeObject(credentials, Formatting.Indented);
            File.WriteAllText(Credential.FileName, credentialstring);

            SaveAdminToFile(admins, fileName);
        }
        public static void UpdateAdmin(int id, string fileName)
        {
            List<Admin> admins = ReadAdminFromFile(fileName);

            File.WriteAllText(fileName, "[]");
            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].Id == id)
                {
                    Console.WriteLine("Name = ");
                    admins[i].Name = Console.ReadLine();
                    Console.WriteLine("PhoneNumber = ");
                    admins[i].PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Role ");
                    admins[i].Role = Console.ReadLine();
                }
            }
            SaveAdminToFile(admins, fileName);
        }

        public static void SaveAdminToFile(List<Admin> admins, string fileName)
        {
            string jsonstring = JsonConvert.SerializeObject(admins, Formatting.Indented);
            File.WriteAllText(FileName, jsonstring);
        }

        public static bool ValidateAdmin(int adminId)
        {
            var admins = ReadAdminFromFile(FileName);

            var list = admins
                .Where(a => a.Id == adminId)
                .ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Student Number");
                return false;
            }

            return true;
        }

        public static Admin GetAdmin(int adminId)
        {
            var admins = ReadAdminFromFile(FileName);

            var chickAdmin = admins
                .Where(a => a.Id == adminId)
                .ToList();

            return chickAdmin[0];
        }

        public static string PrintAdminLogin(Admin admin)
        {
            return $"Admin Id: {admin.Id}  Admin Name: {admin.Name}";
        }
    }
}
