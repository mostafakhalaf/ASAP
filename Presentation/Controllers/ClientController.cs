using Application.Interface.ClientInterface;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICreateClient createClient;
        private readonly IUpdateClient updateClient;
        private readonly IGetClients getClients;
        private readonly IGetClient getClient;
        private readonly IDeleteClient deleteClient;

        public ClientController(ICreateClient createClient, IUpdateClient updateClient,
            IGetClients getClients, IGetClient getClient, IDeleteClient deleteClient)
        {
            this.createClient = createClient;
            this.updateClient = updateClient;
            this.getClients = getClients;
            this.getClient = getClient;
            this.deleteClient = deleteClient;
        }
        [HttpPost("GetClient")]
        public async Task<ActionResult> GetClient(LookUpViewModel model)
        {
            var result = await getClient.Execute(model);
            return Ok(result);
        }
        [HttpPost("GetClients")]
        public async Task<ActionResult> GetClients(PaginationViewModel model)
        {
            var result = await getClients.Execute(model);
            return Ok(result);
        }
        [HttpPost("DeleteClient")]
        public async Task<ActionResult> DeleteClient(LookUpViewModel model)
        {
            var result = await deleteClient.Execute(model);
            return Ok(result);
        }
        [HttpPost("CreateClient")]
        public async Task<ActionResult> CreateClient(ClientViewModel model)
        {
            var result = await createClient.Execute(model);
            return Ok(result);
        }
        [HttpPost("UpdateClient")]
        public async Task<ActionResult> UpdateClient(ClientViewModel model)
        {
            var result = await updateClient.Execute(model);
            return Ok(result);
        }
    }
}
