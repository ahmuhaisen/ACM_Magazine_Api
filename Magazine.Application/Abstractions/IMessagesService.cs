using Magazine.Application.DTOs;

namespace Magazine.Application.Abstractions;
public interface IMessagesService
{
    Task<IEnumerable<MessageDTO>> GetAllAsync();

    Task<int> CreateAsync(MessageDTO message);
}
