using Contracts.DbContext;

public interface IRepositoryManager
{
    IAuthRepo Auth { get; }
    IUserRepo User { get; }
    IAddressRepo Address { get; }
    void Save();
    // ICartRepo Cart { get; }
    // IOrderRepo Order { get; }
    // IProductRepo ProductRepo { get; }
}