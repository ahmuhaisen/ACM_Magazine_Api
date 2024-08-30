using AutoMapper;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Infrastructure.Abstractions;

namespace Magazine.Application.Services;


public class IssuesService(IIssuesRepository _repo,
                           IMapper _mapper) : IIssuesService
{
    public async Task<IEnumerable<IssueDTO>> GetAllAsync()
    {
        var allIssues = await _repo.GetAllAsync();

        if(allIssues is null)
            return Enumerable.Empty<IssueDTO>();

        var data = _mapper.Map<IEnumerable<IssueDTO>>(allIssues);
        
        return data;
    }

    public async Task<IssueDTO> GetByIdAsync(int id)
    {
        var issue = await _repo.GetByIdAsync(id);

        if (issue is null)
            return null!;

        var data = _mapper.Map<IssueDTO>(issue);

        return data;
    }
}
