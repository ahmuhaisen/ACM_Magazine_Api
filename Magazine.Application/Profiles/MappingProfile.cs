using AutoMapper;
using Magazine.Application.DTOs;
using Magazine.Application.Services.Helpers;
using Magazine.Domain;
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

        CreateMap<Contribution, IssueContributorDTO>()
            .ForCtorParam("fullName", (opt) => opt.MapFrom(src => $"{src.Volunteer.FirstName} {src.Volunteer.LastName}"))
            .ForCtorParam("personalImageUrl", (opt) => opt.MapFrom(src => $"{FileManager.VolunteersImagesPath}/{src.Volunteer.PersonalImagePath}"))
            .ForCtorParam("linkedInProfileUrl", (opt) => opt.MapFrom(src => src.Volunteer.LinkedInProfileUrl))
            .ForCtorParam("role", (opt) => opt.MapFrom(src => src.Role.Name));



        CreateMap<Volunteer, VolunteerWithContributionsDTO>()
            .ForMember(dest => dest.PersonalImagePath,
            (opt) => opt.MapFrom(src => $"{FileManager.VolunteersImagesPath}/{src.PersonalImagePath}"));

        CreateMap<Volunteer, VolunteerDTO>()
            .ForMember(dest => dest.PersonalImagePath,
            (opt) => opt.MapFrom(src => $"{FileManager.VolunteersImagesPath}/{src.PersonalImagePath}"));


        CreateMap<Contribution, ContributionDTO>()
            .ForCtorParam("IssueId", (opt) => opt.MapFrom(src => src.IssueId))
            .ForCtorParam("IssueTitle", (opt) => opt.MapFrom(src => src.Issue.Title))
            .ForCtorParam("Role", (opt) => opt.MapFrom(src => src.Role.Name));

        CreateMap< PaginatedList<Issue>, PaginatedList<IssueDTO>>();
        CreateMap< PaginatedList<Volunteer>, PaginatedList<VolunteerDTO>>();

        CreateMap<Message, MessageDTO>();
        CreateMap<MessageDTO, Message>();

        CreateMap<ArticleDTO, Article>();
    }
}
