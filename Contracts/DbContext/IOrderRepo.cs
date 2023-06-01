namespace Contracts.DbContext;


public interface IOrderRepo
{
    Task SaveChanges();
}
