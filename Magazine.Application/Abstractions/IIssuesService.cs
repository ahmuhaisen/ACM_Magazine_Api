using Magazine.Application.DTOs;

namespace Magazine.Application.Abstractions;


public interface IIssuesService
{
    Task<IEnumerable<IssueDTO>> GetAllAsync();
}
