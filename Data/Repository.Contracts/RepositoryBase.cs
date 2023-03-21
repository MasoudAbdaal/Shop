using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Data;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
  protected MainContext MainContext;

  public RepositoryBase(MainContext context) => MainContext = context;


  public IQueryable<T?>? GetEntityByExpression<U>(Expression<Func<T, bool>> condition, bool trachChanges, Expression<Func<T, U>>? entity) where U : T
  {
    if (trachChanges)
      if (entity is null)
        MainContext.Set<T>().Where(condition);

    if (!trachChanges)
      if (entity is not null)
        MainContext.Set<T>()
        .Where(condition)
        .AsNoTracking()
        .Select(entity);

    return default;
  }
}