using Application.Interface.ClientInterface;
using Common.ViewModels;
using DataAccessLayer.IRepositories;
using Domain.Entities;

namespace Application.Service.ClientService
{
    public class DeleteClientService : IDeleteClient
    {
        private readonly IBaseRepository<Client> _clint;

        public DeleteClientService(IBaseRepository<Client> clint)
        {
            _clint = clint;
        }
        public async Task<ResultValues> Execute(LookUpViewModel model)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured in Delete Client",
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
                updatedClient.IsDeleted = true;
                updatedClient.ModifiedAt = DateTime.Now;
                updatedClient.ModifiedBy = "Admin";
                var clientResult = _clint.Update(updatedClient);
                if (clientResult > 0)
                {
                    result.StatusCode = "200";
                    result.Message = "Successfully Create Client";
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
