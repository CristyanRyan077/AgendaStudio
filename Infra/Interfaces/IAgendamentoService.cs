using AgendaApi.Domain.DTOs;

namespace AgendaApi.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoDto>> GetAllAsync();
        Task<AgendamentoDto?> GetByIdAsync(int id);
        Task<AgendamentoDto> CreateAsync(AgendamentoCreateDto dto);
        Task<AgendamentoDto?> UpdateAsync(int id, AgendamentoUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
