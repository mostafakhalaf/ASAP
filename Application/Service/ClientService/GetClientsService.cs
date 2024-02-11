using Application.Interface.ClientInterface;
using AutoMapper;
using Common.ViewModels;
using DataAccessLayer.IRepositories;
using Domain.Entities;

namespace Application.Service.ClientService
{
    public class GetClientsService : IGetClients
    {
        private readonly IBaseRepository<Client> _clint;
        private readonly IMapper mapper;

        public GetClientsService(IBaseRepository<Client> clint, IMapper mapper)
        {
            _clint = clint;
            this.mapper = mapper;
        }
        public async Task<ResultValues> Execute(PaginationViewModel model)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured in Get Clients",
                Success = false,
            };
            try
            {
                int itemsToSkip = (int)((model.PageIndex - 1) * model.PageLimit);
                var clientResult = _clint.FindAll(_ => _.IsDeleted != true, itemsToSkip, model.PageLimit);
                var clientCount = clientResult.Count();
                result.StatusCode = "200";
                result.Message = "Successfully Get Clients";
                result.Success = true;
                result.ReturnObject = clientResult;
                result.TotalCounts = clientCount;
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
