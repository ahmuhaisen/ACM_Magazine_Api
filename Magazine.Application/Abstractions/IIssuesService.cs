using Magazine.Application.DTOs;
using Magazine.Domain;

namespace Magazine.Application.Abstractions;


public interface IIssuesService
{
    Task<IEnumerable<IssueDTO>> GetAllAsync();
    Task<IssueDTO> GetByIdAsync(int id);
    Task<IssueDTO> GetLatestAsync();

    Task<IEnumerable<IssueContributorDTO>> GetIssueTeamAsync(int issueId);
    Task<IEnumerable<IssueContributorDTO>> GetIssueTeamWithRoleAsync(int issueId, int roleId);
    Task<PaginatedList<IssueDTO>> GetIssuesPageAsync(int pageIndex, int pageSize);
}
