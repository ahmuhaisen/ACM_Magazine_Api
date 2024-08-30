using System;

namespace Magazine.Application.DTOs;

public record IssueDTO(
    string Title,
    string Description, 
    byte Number,
    int Year,
    DateTime PublishedAt,
    string CoverImageUrl
);
