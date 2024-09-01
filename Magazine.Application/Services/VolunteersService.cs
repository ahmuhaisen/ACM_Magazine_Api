﻿using AutoMapper;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Infrastructure.Abstractions;

namespace Magazine.Application.Services;

public class VolunteersService(IVolunteersRepository _repo,
                               IMapper _mapper) : IVolunteersService
{
    public async Task<IEnumerable<VolunteerDTO>> GetAllAsync()
    {
        var allVolunteers = await _repo.GetAllAsync();

        if (allVolunteers is null)
            return Enumerable.Empty<VolunteerDTO>();

        var data = _mapper.Map<IEnumerable<VolunteerDTO>>(allVolunteers);

        return data;
    }

    public async Task<VolunteerDTO> GetByIdAsync(int id)
    {
        var volunteer = await _repo.GetByIdAsync(id);

        if (volunteer is null)
            return null!;

        var data = _mapper.Map<VolunteerDTO>(volunteer);

        return data;
    }
    

    public async Task<VolunteerWithContributionsDTO> GetVolunteerWithContributionsByIdAsync(int id)
    {
        var volunteer = await _repo.GetWithContributionsAsync(id);

        if (volunteer is null)
            return null!;

        var data = _mapper.Map<VolunteerWithContributionsDTO>(volunteer);

        return data;
    }
}
