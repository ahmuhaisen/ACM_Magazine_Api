using Magazine.Application.DTOs;

namespace Magazine.Application.Abstractions;

public interface IVolunteersService
{
    Task<IEnumerable<VolunteerDTO>> GetAllAsync();
    Task<VolunteerDTO> GetByIdAsync(int id);
    Task<VolunteerWithContributionsDTO> GetVolunteerWithContributionsByIdAsync(int id);
}