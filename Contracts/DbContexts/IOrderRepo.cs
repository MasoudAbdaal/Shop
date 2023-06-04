namespace Contracts.DbContexts;


public interface IOrderRepo
{
    Task SaveChanges();
}
