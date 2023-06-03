using Contracts.DbContexts;

public interface IRepositoryManager
{
    IAuthRepo Auth { get; }
    // IUserDbContext User { get; }
    IAddressDbContext Address { get; }
    void Save();
    // ICartRepo Cart { get; }
    // IOrderRepo Order { get; }
    // IProductRepo ProductRepo { get; }
}