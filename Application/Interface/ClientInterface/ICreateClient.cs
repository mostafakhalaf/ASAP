using Common.ViewModels;

namespace Application.Interface.ClientInterface
{
    public interface ICreateClient
    {
        public Task<ResultValues> Execute(ClientViewModel model);
    }
}
