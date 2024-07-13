using PrintHub.Core.Entities;
using PrintHub.Core.Enums;

namespace PrintHub.Core.Interfaces.Repositories;

public interface IPrinterRepository
{
    public Task<Printer?> Add(Printer printer);
    
    public Task<Printer?> GetById(uint printerId);
    
    public Task<Printer?> Update(Printer printer);
    
    public Task Delete(Printer printer);

    public Task<IReadOnlyCollection<Printer>> GetAll(ConnectionType? connectionType);
}