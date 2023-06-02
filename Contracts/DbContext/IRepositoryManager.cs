using Contracts.DbContext;

public interface IRepositoryManager
{
    IAuthRepo Auth { get; }
    // IUserDbContext User { get; }
    IAddressRepo Address { get; }
    void Save();
    // ICartRepo Cart { get; }
    // IOrderRepo Order { get; }
    // IProductRepo ProductRepo { get; }
}