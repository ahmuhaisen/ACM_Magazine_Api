﻿namespace Magazine.Application.DTOs;

public class VolunteerDTO
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? PersonalImagePath { get; init; }
    public string? LinkedInProfileUrl { get; init; }
}

public class VolunteerWithContributionsDTO : VolunteerDTO
{
    public IEnumerable<ContributionDTO>? Contributions { get; init; }
}

public class ContributionDTO
{
    public ContributionDTO(int issueId, string issueTitle, string role)
    {
        IssueId = issueId;
        IssueTitle = issueTitle;
        Role = role;
    }

    public int IssueId { get; init; }
    public required string IssueTitle { get; init; }
    public required string Role { get; init; }
}