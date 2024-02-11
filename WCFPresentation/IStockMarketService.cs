using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFPresentation
{
    [ServiceContract]
    public interface IStockMarketService
    {
        [OperationContract]
        Task<ResultValues> FetchAndStoreStockData(string symbol, string startDate);
    }
}
