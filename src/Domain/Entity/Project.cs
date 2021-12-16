using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project: AuditableEntity
    {
        public Project(long id,string name,List<Equipment> lstEquipment=null
            , List<Resource> lstResource = null)
        {
            this.Id = id;
            this.Name = name;
            this.Equipments = lstEquipment;
            this.Resources = lstResource;
        }
        public long Id { get; private set; }
        public string Name { get; private set; }
        public  List<Equipment> Equipments { get; private set; }
        public List<Resource> Resources { get;private set; }


        public bool HasEquipment()
        {
            return Equipments.Count > 0;
        }

        public bool HasResource()
        {
            return Resources.Count > 0;
        }
        public void RemoveEquipment(Equipment equipment)
        {
            Equipments.Remove(equipment);
        }
        public void RemoveResource(Resource resource)
        {
            Resources.Remove(resource);
        }
    }
}
