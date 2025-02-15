using ShopManager.Services.Abstraction;
using ShopManager.Services.Utility.ApiResult;
using System.Linq.Expressions;

namespace ShopManager.Services.Implementation
{
    public class GenericModelService<TEntity, TDto> : IGenericModelService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IMapperService<TEntity, TDto> mapperService;
        private readonly IEntityExtendedService<TEntity> entityService;
        private readonly ServiceMessages serviceMessages;

        public GenericModelService(IMapperService<TEntity, TDto> mapperService, IEntityExtendedService<TEntity> entityService)
        {
            this.mapperService = mapperService;
            this.entityService = entityService;
            this.serviceMessages = new ServiceMessages();
        }
        public IApiResult Add(TDto dto)
        {
            var apiResult = default(IApiResult);

            var entity = mapperService.MapEntity(dto);
            var createResult = entityService.Create(entity);
            apiResult = createResult ? new ApiOkResult(message: serviceMessages.CreateSuccess)
                                     : new ApiErrorResult(loggerErrorMessage: serviceMessages.CreateError, errors: [serviceMessages.CreateError]);

            return apiResult;
        }

        public async Task<IApiResult> AddAsync(TDto dto)
        {
            return await Task.FromResult(Add(dto));
        }

        public IApiResult Delete(object id)
        {
            var apiResult = default(IApiResult);

            var deleteResult = entityService.Delete(id);

            apiResult = deleteResult ? new ApiOkResult(message: serviceMessages.DeleteSuccess)
                                     : new ApiErrorResult(loggerErrorMessage: serviceMessages.DeleteError, errors: [serviceMessages.DeleteError]);

            return apiResult;
        }

        public async Task<IApiResult> DeleteAsync(object id)
        {
            return await Task.FromResult(Delete(id));
        }

        public IApiResult GetAll()
        {
            var entities = entityService.Read().ToArray();
            var dtos = mapperService.MapDtos(entities);

            return new ApiOkResult(data: dtos);
        }

        public async Task<IApiResult> GetAllAsync()
        {
            return await Task.FromResult(GetAll());
        }

        public IApiResult GetAllByCondition(Expression<Func<TEntity, bool>> conditionExpression)
        {
            var entities = entityService.ReadEntitiesByCondition(conditionExpression).ToArray();
            var dtos = mapperService.MapDtos(entities);

            return new ApiOkResult(data: dtos);
        }

        public async Task<IApiResult> GetAllByConditionAsync(Expression<Func<TEntity, bool>> conditionExpression)
        {
            return await Task.FromResult(GetAllByCondition(conditionExpression));
        }

        public IApiResult GetByCondition(Expression<Func<TEntity, bool>> conditionExpression)
        {
            var entity = entityService.ReadByCondition(conditionExpression);
            var dto = mapperService.MapDto(entity);

            return new ApiOkResult(data: dto);
        }

        public async Task<IApiResult> GetByConditionAsync(Expression<Func<TEntity, bool>> conditionExpression)
        {
            return await Task.FromResult(GetByCondition(conditionExpression));
        }

        public IApiResult GetById(object id)
        {
            var apiResult = default(IApiResult);

            var entity = entityService.ReadById(id);
            if (entity == null)
            {
                var errorMessage = string.Format(serviceMessages.GetByIdError, id);
                apiResult = new ApiErrorResult(loggerErrorMessage: errorMessage, errors: [errorMessage]);
            }
            else
            {
                apiResult = new ApiOkResult(data: mapperService.MapDto(entity));
            }

            return apiResult;
        }

        public async Task<IApiResult> GetByIdAsync(object id)
        {
            return await Task.FromResult(GetById(id));
        }

        public IApiResult Update(TDto dto)
        {
            var apiResult = default(IApiResult);

            var newEntity = mapperService.MapEntity(dto);

            var entityIdProperty = newEntity.GetType().GetProperties().FirstOrDefault(prop => prop.Name == "Id");
            var id = entityIdProperty.GetValue(newEntity);
            var oldEntity = entityService.ReadById(id);

            var updatedEntity = entityService.Update(oldEntity, newEntity);

            if (updatedEntity == null)
            {
                var errorMessage = string.Format(serviceMessages.UpdateError, id);
                apiResult = new ApiErrorResult(loggerErrorMessage: errorMessage, errors: [errorMessage]);
            }
            else
            {
                var successMessage = string.Format(serviceMessages.UpdateSuccess, id);
                var updatedDto = mapperService.MapDto(updatedEntity);
                apiResult = new ApiOkResult(message: successMessage, data: updatedDto);
            }

            return apiResult;
        }

        public async Task<IApiResult> UpdateAsync(TDto dto)
        {
            return await Task.FromResult(Update(dto));
        }

        internal class ServiceMessages
        {
            internal static string InstanceOf { get; set; } = $"instance of {typeof(TEntity).Name}";
            internal string CreateError { get; set; } = $"Could not create a new {InstanceOf}";
            internal string CreateSuccess { get; set; } = $"Created a new {InstanceOf}";
            internal string DeleteError { get; set; } = $"Could not delete an {InstanceOf}. Id = {{0}}.";
            internal string DeleteSuccess { get; set; } = $"Deleted an {InstanceOf}. Id = {{0}}.";
            internal string GetByIdError { get; set; } = $"Could not retreive an {InstanceOf}. Id = {{0}}.";
            internal string GetByIdSuccess { get; set; } = $"Retreived an {InstanceOf}. Id = {{0}}.";
            internal string UpdateError { get; set; } = $"Could not update an {InstanceOf}. Id = {{0}}";
            internal string UpdateSuccess { get; set; } = $"Updated an {InstanceOf}. Id = {{0}}";
        }
    }
}
