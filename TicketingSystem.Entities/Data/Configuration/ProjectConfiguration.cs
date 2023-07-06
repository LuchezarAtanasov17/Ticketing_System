using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicketingSystem.Entities.Models;
namespace TicketingSystem.Entities.Data.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(SeedProjects());
        }
        private List<Project> SeedProjects()
        {
            var projects = new List<Project>();

            Project project = new Project()
            {
                Id = Guid.Parse("0c1b871b-4ed5-4299-aec4-d59054b07c54"),
                Name = "LAAuto",
                Description = "Luchezar's project for SoftUni.",
            };
            projects.Add(project);

            project = new Project()
            {
                Id = Guid.Parse("83da1e75-3b7d-4a37-a33d-ba8cf149acb8"),
                Name = "Weather forecasting system",
                Description = "Shows weather analysis.",
            };
            projects.Add(project);

            project = new Project()
            {
                Id = Guid.Parse("8c97398e-09d8-4823-a82d-343619758e81"),
                Name = "Instagram",
            };
            projects.Add(project);

            return projects;
        }
    }
}
