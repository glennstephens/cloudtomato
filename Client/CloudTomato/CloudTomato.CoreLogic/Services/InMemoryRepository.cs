using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTomato.CoreLogic.Models;

namespace CloudTomato.CoreLogic.Services
{
    public class InMemoryRepository : IDataRepository
    {
        List<PomodoraSession> sessions = new List<PomodoraSession>();

        public async Task<PomodoraSession> AddNewSession(PomodoraSession session)
        {
            sessions.Add(session);
            return await Task.FromResult(session);
        }

        List<Project> projects = new List<Project>();

        public async Task<bool> DeleteProject(Guid id)
        {
            var foundProject = await GetProjectById(id);

            if (foundProject != null)
                projects.Remove(foundProject);

            return await Task.FromResult(true);
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await Task.FromResult(projects);
        }

        public async Task<bool> SaveProject(Project project)
        {
            projects.Add(project);

            return await Task.FromResult(true);
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            return await Task.FromResult(projects.Where(p => p.Id == id).FirstOrDefault());
        }
    }
}
