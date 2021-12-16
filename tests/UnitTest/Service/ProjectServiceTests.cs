using Domain;
using Domain.Repositories;
using Domain.Services;
using Domain.UnitOfWork;
using Moq;
using Moq.AutoMock;
using Service;
using System.Collections.Generic;
using System.Linq;
using UnitTest.Fixture;
using Xunit;

namespace UnitTest.Service
{
    [Collection(nameof(ProjectAutoMockerCollection))]
    public class ProjectServiceTests
    {
        readonly ProjectServiceFixtureTests _projectServiceFixtureTests;
        //    1 - objetoEmTeste_MetodoOuComportametoEmteste_ComportamentoEsperado
        //    ex: Pedido_AdicionarPedidoItem_DeveIncrementarUnidadesSeItemJaExistente
        //    Estoque_RetirarItem_DeveEnviarEmailSeAbaixoDe10Unidades

        //    2 - MetodoEmTeste_EstadoEmTeste_ComportamentoEsperado
        //    Ex: AdicionarPedidoItem_ItemExistenteCarrinho_DeveIncrementarUnidadesDoItem
        //    RetirarEstoque_EstoqueAbaixoDe10Unidades_DeveEnviarEmailDeAviso

        private Mock<IProjectRepository> _mockRepository;
        private IProjectService _service;
        Mock<IUnitOfWork> _mockUnitWork;

        public ProjectServiceTests(ProjectServiceFixtureTests projectServiceFixtureTests)
        {
            _projectServiceFixtureTests = projectServiceFixtureTests;
            _service = _projectServiceFixtureTests.GetProjectService();
        }

        [Theory(DisplayName ="New Projects with Equipment And Resources")]
        [Trait("Project","Project Service Mock Tests")]
        [InlineData(100,50,60)]
        [InlineData(5,1,1)]
        [InlineData(1,1,1)]
        public void GetAll_WithEquipmentAndResouce_MustSuccess(int qtdProject,int qtdEquipment,int qtdResource){
            //Arrange 
            _projectServiceFixtureTests.Mocker.GetMock<IProjectRepository>().Setup(c => c.GetAll())
                .Returns(_projectServiceFixtureTests.CreateProjectsWithDependencies(qtdProject, qtdEquipment, qtdResource));
            
            //Act
            var projects = _service.GetAll();

            //Assert
            _projectServiceFixtureTests.Mocker.GetMock<IProjectRepository>().Verify(r => r.GetAll(), Times.Once);
            
            Assert.True(projects.Any());
            Assert.True(projects.Select(x => x.Equipments).FirstOrDefault().Count() > 0);
            Assert.True(projects.Select(x => x.Resources).FirstOrDefault().Count() > 0);            
        }


        [Fact(DisplayName = "New Projects with Equipment And Resources")]
        [Trait("Project", "Project Service Mock Tests")]        
        public void GetAll_WithEquipmentAndResouce_MustSuccess_WithMockDirect()
        {
            //Arrange 
            List<Project> lstProject = new List<Project>();
            List<Equipment> lstEquipment = new List<Equipment>();
            List<Resource> lstResource = new List<Resource>();

            lstEquipment.Add(new Equipment("Martelo"));
            lstResource.Add(new Resource("Glauco", "Oliveira", 33));
            lstProject.Add(new Project(9, "Obra 1", lstEquipment, lstResource));


            var repository = new Mock<IProjectRepository>();
            var service = new ProjectService(repository.Object);            

            repository.Setup(r => r.GetAll()).Returns(lstProject);
            //Act
            var projects = service.GetAll();

            //Assert            
            Assert.True(projects.Any());
            Assert.True(projects.Select(x => x.Equipments).FirstOrDefault().Count() > 0);
            Assert.True(projects.Select(x => x.Resources).FirstOrDefault().Count() > 0);
        }

        [Fact(DisplayName = "Create Projects with Equipment And Resources")]
        [Trait("Project", "Project Service Mock Tests")]
        public void GetAll_WithEquipmentAndResouce_MustSuccess_WithAutoMock()
        {
            //Arrange 
            List<Project> lstProject = new List<Project>();
            List<Equipment> lstEquipment = new List<Equipment>();
            List<Resource> lstResource = new List<Resource>();

            
            lstEquipment.Add(new Equipment("Martelo"));
            lstResource.Add(new Resource("Glauco", "Oliveira", 33));
            lstProject.Add(new Project(9, "Obra 1",lstEquipment,lstResource));

            var  mocker = new AutoMocker();
            var projectService = mocker.CreateInstance<ProjectService>();
            var repository = mocker.GetMock<IProjectRepository>();

            repository.Setup(r => r.GetAll()).Returns(lstProject);
            //Act
            var projects = projectService.GetAll();

            //Assert            
            Assert.True(projects.Any());
            Assert.True(projects.Select(x => x.Equipments).FirstOrDefault().Count() > 0);
            Assert.True(projects.Select(x => x.Resources).FirstOrDefault().Count() > 0);
        }


        [Theory(DisplayName = "Create Projects with Equipment And without Resources")]
        [Trait("Project", "Project Service Mock Tests")]
        [InlineData(100, 50, 0)]
        [InlineData(5, 1, 0)]
        [InlineData(1, 1, 0)]
        public void GetAll_WithEquipmentAndWithoutResouce_MustSuccess(int qtdProject, int qtdEquipment, int qtdResource)
        {
            //Arrange 
            _projectServiceFixtureTests.Mocker.GetMock<IProjectRepository>().Setup(c => c.GetAll())
                .Returns(_projectServiceFixtureTests.CreateProjectsWithDependencies(qtdProject, qtdEquipment, qtdResource));

            //Act
            var projects = _service.GetAll();

            //Assert
            _projectServiceFixtureTests.Mocker.GetMock<IProjectRepository>().Verify(r => r.GetAll(), Times.Once);

            Assert.True(projects.Any());
            Assert.True(projects.FirstOrDefault().HasEquipment());
            Assert.False(projects.FirstOrDefault().HasResource());
            Assert.True(projects.Select(x => x.Equipments).Count() > 0);
            Assert.True(projects.Select(x => x.Resources).FirstOrDefault().Count() == 0);
        }

      
    }
}
//Cobertura de codigo
//https://renatogroffe.medium.com/net-5-cobertura-de-testes-com-coverlet-7cbec2f052d9
