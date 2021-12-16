using Domain.Base;
using System;

namespace Domain
{
    public class Equipment : AuditableEntity
    {
        public Equipment(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }
}
