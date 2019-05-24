using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudTomato.CoreLogic.Models;

namespace CloudTomato.CoreLogic.Services
{
    public interface IDataRepository
    {
        // Project Details
        Task<List<Project>> GetAllProjects();
        Task<bool> SaveProject(Project project);
        Task<bool> DeleteProject(Guid id);
        Task<Project> GetProjectById(Guid id);

        // Sessions
        Task<PomodoraSession> AddNewSession(PomodoraSession session);
    }
}
