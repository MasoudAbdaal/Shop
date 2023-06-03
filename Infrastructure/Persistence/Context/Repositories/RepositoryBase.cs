// using System.Linq.Expressions;
// using Contracts.DbContext;
// using Infrastructure.Context;
// using Microsoft.EntityFrameworkCore;


// public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
// {
//     protected MainContext MainContext;

//     public RepositoryBase(MainContext context) => MainContext = context;


//     public IQueryable<T?>? GetBy<U>(Expression<Func<T, bool>> condition, bool trachChanges, Expression<Func<T, U>>? entity, Func<T, U>? orderBy) where U : T
//     {
//         var result = trachChanges ? MainContext.Set<T>().AsNoTracking() : MainContext.Set<T>();
//         result.Where(condition);

//         if (orderBy is not null)
//             result.OrderBy(orderBy);

//         if (entity is not null)
//             result.Select(entity);


//         return result;
//     }
// }