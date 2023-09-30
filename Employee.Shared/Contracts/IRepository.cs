using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Shared.Contracts;

public interface IRepository<TEntity,IModel,T> 
    where TEntity : class,IEntity<T>,new()
    where IModel : class,IVM<T>, new()
    where T :IEquatable<T>
{
    /// <summary>
    /// Gets by identifier asyncrouns
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IModel> GetByIdAsync(T Id);
    /// <summary>
    /// Get All Async
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<IModel>> GetAllAsync();
    /// <summary>
    /// Get All Async
    /// </summary>
    /// <param name="includes"></param>
    /// <returns></returns>
    public Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    /// <summary>
    /// Delete The Async
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task DeleteAsync(TEntity entity);
    /// <summary>
    /// Delete the asyncronous
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<IModel> DeleteAsync(T Id);
    /// <summary>
    /// Update the async
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<IModel> UpdateAsync(T Id, TEntity entity);
    /// <summary>
    /// Insert Async
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<IModel> InsertAsync(TEntity entity);
}
