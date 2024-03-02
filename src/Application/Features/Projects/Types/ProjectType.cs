using GraphQL.Types;
using MindworkingTest.Application.Features.Technologies.Types;
using MindworkingTest.Domain.Models;

namespace MindworkingTest.Application.Features.Projects.Types;

public sealed class ProjectType : ObjectGraphType<Project>
{
    public ProjectType()
    {
        Name = nameof(Project);
        Description = "Projects worked on";
        Field(t => t.Id, nullable: false);
        Field(t => t.Title, nullable: false)
            .Description("Project title");
        Field(t => t.Description, nullable: false)
            .Description("Project description");
        Field(t => t.StartDate, nullable: false)
            .Description("Project description");
        Field(t => t.EndDate, nullable: true)
            .Description("Project end date");
        Field<ListGraphType<TechnologyType>>("technologies")
            .Description("Technologies used on project")
            .Resolve(context =>
                context.Source.Technologies
            );
    }
}