using Common.ViewModels;

namespace Application.Interface.ClientInterface
{
    public interface IGetClient
    {
        public Task<ResultValues> Execute(LookUpViewModel model);
    }
}
