using Common.ViewModels;

namespace Application.Interface.ClientInterface
{
    public interface IDeleteClient
    {
        public Task<ResultValues> Execute(LookUpViewModel model);
    }
}
