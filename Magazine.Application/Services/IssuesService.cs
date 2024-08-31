using AutoMapper;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Microsoft.Extensions.Logging;

namespace Magazine.Application.Services;


public class IssuesService(IIssuesRepository _repo,
                           IContributionsRepository _contributionRepo,
                           IMapper _mapper) : IIssuesService
{
    public async Task<IEnumerable<IssueDTO>> GetAllAsync()
    {
        var allIssues = await _repo.GetAllAsync();

        if (allIssues is null)
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

    public async Task<IEnumerable<IssueContributorDTO>> GetIssueTeam(int issueId)
    {
        var contributions = await _contributionRepo.GetContributionsByIssueId(issueId);

        if (contributions is null || !contributions.Any())
            return Enumerable.Empty<IssueContributorDTO>();

        var data = _mapper.Map<IEnumerable<IssueContributorDTO>>(contributions);

        return data;
    }

    public async Task<IEnumerable<Contribution>> TestIssueTeam(int issueId)
    {
        return await _contributionRepo.GetContributionsByIssueId(issueId);

      
    }
}
