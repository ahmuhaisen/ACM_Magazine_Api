using AutoMapper;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;

namespace Magazine.Application.Services;


public class MessagesService(IMessagesRepository _repo, IMapper _mapper) : IMessagesService
{
    public async Task<IEnumerable<MessageDTO>> GetAllAsync()
    {
        var allMessages = await _repo.GetAllAsync();

        if(allMessages is null)
            return Enumerable.Empty<MessageDTO>();

        var result = _mapper.Map<IEnumerable<MessageDTO>>(allMessages);

        return result;
    }


    public async Task<int> CreateAsync(MessageDTO message)
    {
        if (message is null)
            return await Task.FromResult(-1);

        var messageToCreate = _mapper.Map<Message>(message);

        return await _repo.CreateAsync(messageToCreate);
    }
}
