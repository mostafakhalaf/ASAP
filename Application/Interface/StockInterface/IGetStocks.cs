using Common.ViewModels;

namespace Application.Interface.StockInterface
{
    public interface IGetStocks
    {
        public Task<ResultValues> Execute(PaginationViewModel model);
    }
}
