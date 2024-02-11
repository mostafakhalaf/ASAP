using Application.Interface.ClientInterface;
using AutoMapper;
using Common.ViewModels;
using DataAccessLayer.IRepositories;
using Domain.Entities;

namespace Application.Service.ClientService
{
    public class UpdateClientService : IUpdateClient
    {
        private readonly IBaseRepository<Client> _clint;
        private readonly IMapper mapper;

        public UpdateClientService(IBaseRepository<Client> clint, IMapper mapper)
        {
            _clint = clint;
            this.mapper = mapper;
        }
        public async Task<ResultValues> Execute(ClientViewModel model)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured in update Client",
                Success = false,
            };
            try
            {
                var updatedClient = await _clint.FindAsync(_ => _.Id == model.Id);
                if (updatedClient == null)
                {
                    result.Success = false;
                    result.Message = "Not found";
                    return result;
                }
                var client = mapper.Map<Client>(model);
                var clientResult = _clint.Update(client);
                if (clientResult > 0)
                {
                    result.StatusCode = "200";
                    result.Message = "Successfully Update Client";
                    result.Success = true;
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
