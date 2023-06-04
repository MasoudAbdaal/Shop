namespace Contracts.DbContexts;


public interface IProductRepo
{
    Task SaveChanges();
}
