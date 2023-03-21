using System.Linq.Expressions;

public interface IRepositoryBase<T>
{
  //U Is Optional here!
  IQueryable<T?>? GetEntityByExpression<U>(Expression<Func<T, bool>> condition, bool trachChanges, Expression<Func<T, U>>? entity) where U : T;
}