using Common.ViewModels;

namespace Application.Interface.ClientInterface
{
    public interface IUpdateClient
    {
        public Task<ResultValues> Execute(ClientViewModel model);
    }
}
