using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity
    {

    }

    public abstract class Entity : BaseEntity, IEntity
    {
        public virtual long Id { get; set; }
    }
}
