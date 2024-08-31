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

        //CreateMap<Contribution, IssueContributorDTO>()
        //    .ForMember(
        //    dest => dest.FullName,
        //    (opt) => opt.MapFrom(src => $"{src.Volunteer.FirstName} {src.Volunteer.LastName}")
        //    )
        //    .ForMember(
        //    dest => dest.PersonalImageUrl,
        //    (opt) => opt.MapFrom(src => $"{FileManager.VolunteersImagesPath}/{src.Volunteer.PersonalImagePath}")
        //    )
        //    .ForMember(
        //    dest => dest.LinkedInProfileUrl,
        //    opt => opt.MapFrom(src => src.Volunteer.LinkedInProfileUrl)
        //    )
        //    .ForMember(
        //    dest => dest.Role,
        //    (opt) => opt.MapFrom(src => src.Role.Name)
        //    );

        CreateMap<Contribution, IssueContributorDTO>()
            .ForCtorParam("fullName", (opt) => opt.MapFrom(src => $"{src.Volunteer.FirstName} {src.Volunteer.LastName}"))
            .ForCtorParam("personalImageUrl", (opt) => opt.MapFrom(src => $"{FileManager.VolunteersImagesPath}/{src.Volunteer.PersonalImagePath}"))
            .ForCtorParam("linkedInProfileUrl", (opt) => opt.MapFrom(src => src.Volunteer.LinkedInProfileUrl))
            .ForCtorParam("role", (opt) => opt.MapFrom(src => src.Role.Name));
    }
}
