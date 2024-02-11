using Common.ViewModels;

namespace Application.Interface.StockInterface
{
    public interface ICreateStock
    {
        public Task<ResultValues> Execute(List<PolygonApiResultViewModel> model);
    }
}
