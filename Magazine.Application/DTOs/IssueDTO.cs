using System;

namespace Magazine.Application.DTOs;


public class IssueDTO
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public byte Number { get; init; }
    public int Year { get; init; }
    public DateTime PublishedAt { get; init; }
    public required string CoverImageUrl { get; init; }
}
