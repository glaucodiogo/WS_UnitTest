using Domain;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IList<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }
        //public long AddProject(Project project)
        //{

        //}
    }
}
