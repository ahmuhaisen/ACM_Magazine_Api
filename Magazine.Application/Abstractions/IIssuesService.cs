using Magazine.Application.DTOs;
using Magazine.Domain;

namespace Magazine.Application.Abstractions;


public interface IIssuesService
{
    Task<IEnumerable<IssueDTO>> GetAllAsync();
    Task<IssueDTO> GetByIdAsync(int id);
    Task<IssueDTO> GetLatestAsync();

    Task<IEnumerable<IssueContributorDTO>> GetIssueTeam(int issueId);
    Task<IEnumerable<IssueContributorDTO>> GetIssueTeamWithRole(int issueId, int roleId);
    Task<PaginatedList<IssueDTO>> GetIssuesPage(int pageIndex, int pageSize);
}
