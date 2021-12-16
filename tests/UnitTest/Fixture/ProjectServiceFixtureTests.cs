using Bogus;
using Bogus.DataSets;
using Domain;
using Moq.AutoMock;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTest.Fixture
{
    [CollectionDefinition(nameof(ProjectAutoMockerCollection))]
    public class ProjectAutoMockerCollection : ICollectionFixture<ProjectServiceFixtureTests>
    {
    }
    public class ProjectServiceFixtureTests : IDisposable
    {
        public AutoMocker Mocker;
        public ProjectService ProjectService;

        public Project GenerateProjectAvailable()
        {
            return CreateProjectsWithDependencies(1,2,2).FirstOrDefault();
        }
        public List<Project> CreateProjectsWithoutDependencies(int quantity)
        {
            var projects = new Faker<Project>("pt_BR")
                .CustomInstantiator(f => new Project(
                    f.Random.Long(),
                    f.Random.Word(),
                    null,
                    null
                    ));
                

            return projects.Generate(quantity);
        }

        public List<Project> CreateProjectsWithDependencies(int quantity,int equipmentQtd,int resourceQtd)
        {
            var equipments = this.CreateEquipments(equipmentQtd);
            var resources = this.CreateResources(resourceQtd);

            var projects = new Faker<Project>("pt_BR")
                .CustomInstantiator(f => new Project(
                    f.Random.Long(),
                    f.Random.Word(),
                    this.CreateEquipments(equipmentQtd),
                    this.CreateResources(resourceQtd)                    
                    ));


            return projects.Generate(quantity);
        }
        public List<Equipment> CreateEquipments(int quantity)
        {
            var equipments = new Faker<Equipment>("pt_BR")
                .CustomInstantiator(f => new Equipment(                    
                    f.Random.Word()
                    ));


            return equipments.Generate(quantity);
        }

        public List<Resource> CreateResources(int quantity)
        {
            var resources = new Faker<Resource>("pt_BR")
                .CustomInstantiator(f => new Resource(
                    f.Person.FirstName,
                    f.Person.LastName,
                    f.Random.Int()
                    ));

            return resources.Generate(quantity);
        }
        public ProjectService GetProjectService()
        {
            Mocker = new AutoMocker();
            ProjectService = Mocker.CreateInstance<ProjectService>();
            return ProjectService;
        }
        public void Dispose()
        {
            
        }
    }
}
