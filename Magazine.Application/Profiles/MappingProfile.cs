using AutoMapper;
using Magazine.Application.DTOs;
using Magazine.Application.Services.Helpers;
using Magazine.Domain.Entities;

namespace Magazine.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Issue, IssueDTO>()
            .ForMember(
            dest => dest.CoverImageUrl,
            (opt) => opt.MapFrom(src => $"{FileManager.IssuesCoverImagesPath}/{src.CoverImageUrl}")
            );
    }
}
