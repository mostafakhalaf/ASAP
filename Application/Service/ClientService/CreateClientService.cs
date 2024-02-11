using Application.Interface.ClientInterface;
using AutoMapper;
using Common.ViewModels;
using DataAccessLayer.IRepositories;
using Domain.Entities;

namespace Application.Service.ClientService
{
    public class CreateClientService : ICreateClient
    {
        private readonly IBaseRepository<Client> _clint;
        private readonly IMapper mapper;

        public CreateClientService(IBaseRepository<Client> clint, IMapper mapper)
        {
            _clint = clint;
            this.mapper = mapper;
        }


        public async Task<ResultValues> Execute(ClientViewModel model)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured in Create Client",
                Success = false,
            };
            try
            {
                var client = mapper.Map<Client>(model);
                client.Id = Guid.NewGuid();
                client.ModifiedAt = DateTime.Now;
                var clientResult = await _clint.AddAsync(client);
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
