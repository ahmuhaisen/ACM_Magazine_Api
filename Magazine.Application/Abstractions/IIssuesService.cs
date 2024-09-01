using Magazine.Application.DTOs;

namespace Magazine.Application.Abstractions;


public interface IIssuesService
{
    Task<IEnumerable<IssueDTO>> GetAllAsync();
    Task<IssueDTO> GetByIdAsync(int id);
    Task<IEnumerable<IssueContributorDTO>> GetIssueTeam(int issueId);
    Task<IEnumerable<IssueContributorDTO>> GetIssueTeamWithRole(int issueId, int roleId);
}
