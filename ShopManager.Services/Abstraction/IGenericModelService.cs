using ShopManager.Services.Utility.ApiResult;
using System.Linq.Expressions;

namespace ShopManager.Services.Abstraction
{
    public interface IGenericModelService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        IApiResult Add(TDto dto);
        Task<IApiResult> AddAsync(TDto dto);
        IApiResult Delete(object id);
        Task<IApiResult> DeleteAsync(object id);
        IApiResult Update(TDto dto);
        Task<IApiResult> UpdateAsync(TDto dto);
        IApiResult GetById(object id);
        Task<IApiResult> GetByIdAsync(object id);
        IApiResult GetByCondition(Expression<Func<TEntity, bool>> conditionExpression);
        Task<IApiResult> GetByConditionAsync(Expression<Func<TEntity, bool>> conditionExpression);
        IApiResult GetAll();
        Task<IApiResult> GetAllAsync();
        IApiResult GetAllByCondition(Expression<Func<TEntity, bool>> conditionExpression);
        Task<IApiResult> GetAllByConditionAsync(Expression<Func<TEntity, bool>> conditionExpression);
    }
}
