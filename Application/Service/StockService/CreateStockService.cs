using Application.Interface.StockInterface;
using AutoMapper;
using Common.ViewModels;
using DataAccessLayer.IRepositories;
using Domain.Entities;

namespace Application.Service.StockService
{
    public class CreateStockService : ICreateStock
    {
        private readonly IBaseRepository<PolygonApiResult> _polygonApiResult;
        private readonly IMapper mapper;

        public CreateStockService(IBaseRepository<PolygonApiResult> polygonApiResult, IMapper mapper)
        {
            _polygonApiResult = polygonApiResult;
            this.mapper = mapper;
        }


        public async Task<ResultValues> Execute(List<PolygonApiResultViewModel> model)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured in Create Client",
                Success = false,
            };
            try
            {
                var polygonApiResult = mapper.Map<List<PolygonApiResult>>(model);
                polygonApiResult.ForEach(_ =>
                {
                    _.Id = Guid.NewGuid();
                    _.ModifiedAt = DateTime.Now;
                });
                var clientResult = await _polygonApiResult.AddRangeAsync(polygonApiResult);
                if (clientResult > 0)
                {
                    result.StatusCode = "200";
                    result.Message = "Successfully Create Client";
                    result.Success = true;
                    result.ReturnObject = model;
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
