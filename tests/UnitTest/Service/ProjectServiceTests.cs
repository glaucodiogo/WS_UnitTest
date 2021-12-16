using Domain;
using Domain.Repositories;
using Domain.Services;
using Domain.UnitOfWork;
using Moq;
using Service;
using System.Collections.Generic;
using System.Linq;
using UnitTest.Fixture;
using Xunit;

namespace UnitTest.Service
{
    [Collection(nameof(ClienteAutoMockerCollection))]
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

        [Theory(DisplayName ="Create Projects with Equipment And Resources with Success")]
        [Trait("Project","Project Service Mock Tests")]
        [InlineData(100,50,60)]
        [InlineData(5,1,1)]
        [InlineData(1,1,1)]
        public void CreateProject_WithEquipmentAndResouce_WithSuccess(int qtdProject,int qtdEquipment,int qtdResource){
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

        [Theory(DisplayName = "Create Projects with Equipment And Resources with Success")]
        [Trait("Project", "Project Service Mock Tests")]
        [InlineData(100, 50, 0)]
        [InlineData(5, 1, 0)]
        [InlineData(1, 1, 0)]
        public void CreateProject_WithEquipmentAndWithoutResouce_WithSuccess(int qtdProject, int qtdEquipment, int qtdResource)
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
            Assert.True(projects.FirstOrDefault().HasResource());
            Assert.True(projects.Select(x => x.Equipments).Count() > 0);
            Assert.True(projects.Select(x => x.Resources).FirstOrDefault().Count() == 0);
        }

        [Fact]
        public void RemoveResource()
        {
            //Arrange
            List<Resource> lstResources = new List<Resource>();

            lstResources.Add(new Resource()
            {
                Id = 1 ,
                Age = 32,
                Name = "Joao",
                LastName = "Oliveira",
                CreatedDate = DateTime.Now
            })
            var objProject = new Project(2,"ProjectOne",null,);
            //Act
            Resource.remove
            //Assert
        }
    }
}
//Cobertura de codigo
//https://renatogroffe.medium.com/net-5-cobertura-de-testes-com-coverlet-7cbec2f052d9
