using Magazine.Application.DTOs;
using Magazine.Domain;

namespace Magazine.Application.Abstractions;

public interface IVolunteersService
{
    Task<IEnumerable<VolunteerDTO>> GetAllAsync();
    Task<VolunteerDTO> GetByIdAsync(int id);
    Task<VolunteerWithContributionsDTO> GetVolunteerWithContributionsByIdAsync(int id);
    Task<IEnumerable<VolunteerDTO>> GetTopContributorsAsync(int number);
    Task<PaginatedList<VolunteerDTO>> GetVolunteersPageAsync(int pageIndex, int pageSize);
}