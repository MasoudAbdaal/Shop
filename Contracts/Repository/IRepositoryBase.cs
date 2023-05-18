using System.Linq.Expressions;

public interface IRepositoryBase<T>
{
  //U Is Optional here!
  IQueryable<T?>? GetBy<U>(Expression<Func<T, bool>> condition, bool trachChanges, Expression<Func<T, U>>? entity, Func<T, U> ? orderBy = null) where U : T;
}