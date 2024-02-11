using Application.Interface.RecurringJob;
using Hangfire;

namespace Application.Service.RecurringJobService
{
    public class RecurringJobService : IRecurringJobHandler
    {
        public void ExecuteJob()
        {
            //in thise service we will send emaill and get wcf service
            RecurringJob.AddOrUpdate("RecurringJobId", () => Console.WriteLine("Job executed at: " + DateTime.Now), Cron.Hourly(6));
        }
    }
}
