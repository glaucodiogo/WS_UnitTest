using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Resource : AuditableEntity
    {
        public Resource(string name,string lastName,int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
        }
        public string Name { get; private set; }
        public string LastName { get;private set; }
        public int Age { get;private set; }

    }
}
