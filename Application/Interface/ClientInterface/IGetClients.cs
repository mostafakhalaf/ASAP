using Common.ViewModels;

namespace Application.Interface.ClientInterface
{
    public interface IGetClients
    {
        public Task<ResultValues> Execute(PaginationViewModel model);
    }
}
