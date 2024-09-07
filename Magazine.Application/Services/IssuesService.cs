using AutoMapper;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Domain;
using Magazine.Infrastructure.Abstractions;

namespace Magazine.Application.Services;


public class IssuesService(IIssuesRepository _repo,
                           IContributionsRepository _contributionRepo,
                           IMapper _mapper) : IIssuesService
{
    public async Task<IEnumerable<IssueShortInfo>> GetAllAsync()
    {
        var allIssues = await _repo.GetAllShortAsync();

        if (allIssues is null)
            return Enumerable.Empty<IssueShortInfo>();

        return allIssues;
    }

    public async Task<IssueDTO> GetByIdAsync(int id)
    {
        var issue = await _repo.GetByIdAsync(id);

        if (issue is null)
            return null!;

        var data = _mapper.Map<IssueDTO>(issue);

        return data;
    }

    public async Task<IssueDTO> GetLatestAsync()
    {
        var latest = await _repo.LatestAsync();

        if (latest is null) return null!;

        var data = _mapper.Map<IssueDTO>(latest);

        return data;
    }


    public async Task<IEnumerable<IssueContributorDTO>> GetIssueTeamAsync(int issueId)
    {
        var contributions = await _contributionRepo.GetContributionsByIssueId(issueId);

        if (contributions is null || !contributions.Any())
            return Enumerable.Empty<IssueContributorDTO>();

        var data = _mapper.Map<IEnumerable<IssueContributorDTO>>(contributions);

        return data;
    }

    public async Task<IEnumerable<IssueContributorDTO>> GetIssueTeamWithRoleAsync(int issueId, int roleId)
    {
        var contributions = await _contributionRepo.GetContributionsByIssueIdAndRoleId(issueId, roleId);

        if (contributions is null || !contributions.Any())
            return Enumerable.Empty<IssueContributorDTO>();

        var data = _mapper.Map<IEnumerable<IssueContributorDTO>>(contributions);

        return data;
    }

    public async Task<PaginatedList<IssueDTO>> GetIssuesPageAsync(int pageIndex, int pageSize)
    {
        var paginatedList = await _repo.GetPageAsync(pageIndex, pageSize, i => i.PublishedAt);

        var data = _mapper.Map<PaginatedList<IssueDTO>>(paginatedList);

        return data;
    }
}
