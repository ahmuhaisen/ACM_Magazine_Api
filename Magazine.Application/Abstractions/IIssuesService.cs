using Magazine.Application.DTOs;
using Magazine.Domain.Entities;

namespace Magazine.Application.Abstractions;


public interface IIssuesService
{
    Task<IEnumerable<IssueDTO>> GetAllAsync();
    Task<IssueDTO> GetByIdAsync(int id);
    Task<IEnumerable<IssueContributorDTO>> GetIssueTeam(int issueId);
}


