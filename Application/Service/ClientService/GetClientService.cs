using Application.Interface.ClientInterface;
using AutoMapper;
using Common.ViewModels;
using DataAccessLayer.IRepositories;
using Domain.Entities;

namespace Application.Service.ClientService
{
    public class GetClientService : IGetClient
    {
        private readonly IBaseRepository<Client> _clint;
        private readonly IMapper mapper;

        public GetClientService(IBaseRepository<Client> clint, IMapper mapper)
        {
            _clint = clint;
            this.mapper = mapper;
        }


        public async Task<ResultValues> Execute(LookUpViewModel model)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured in Get Client",
                Success = false,
            };
            try
            {
                var clientResult = await _clint.FindAsync(_ => _.IsDeleted != true && _.Id == model.Id);
                if (clientResult == null)
                {
                    result.Success = false;
                    result.Message = "Not found";
                    return result;
                }
                var client = mapper.Map<ClientViewModel>(clientResult);
                result.StatusCode = "200";
                result.Message = "Successfully Get Client";
                result.Success = true;
                result.ReturnObject = client;
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
