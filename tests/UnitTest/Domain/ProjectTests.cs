using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Domain
{
   public  class ProjectTests
    {
        [Fact]
        public void RemoveResource()
        {
            //Arrange
            List<Resource> lstResources = new List<Resource>();
            var objResource = new Resource("João", "Oliveira", 23);

            lstResources.Add(objResource);

            var objProject = new Project(2, "ProjectOne", null, lstResources);

            //Act
            objProject.RemoveResource(objResource);
            //Assert

            Assert.False(objProject.HasResource());
        }
    }
}
