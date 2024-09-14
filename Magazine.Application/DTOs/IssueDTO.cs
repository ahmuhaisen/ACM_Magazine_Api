using System;

namespace Magazine.Application.DTOs;


public class IssueDTO
{
    public int Id { get; set; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public byte Number { get; init; }

    public DateTime PublishedAt { get; init; }
    public required string FlipHtmlUrl { get; set; }
    public required string DirectorNote { get; set; } 

    public required string CoverImageUrl { get; init; }
}
