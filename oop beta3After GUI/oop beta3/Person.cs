using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace oop_beta3
{
    public class Person
    {
       public int Id;
        public string Name;
        public string Address;
        public string PhoneNumber;
        public string Role;

        public Person(int id, string name , string address , string phone , string role)
        {
            this.Id = id;
            this.Name = name;   
            this.Address = address;  
            this.PhoneNumber = phone;
            this.Role = role;   
        }
             
        
    }
}
