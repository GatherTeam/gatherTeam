using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using gatherteamprojectService.DataObjects;
using gatherteamprojectService.Models;

namespace gatherteamprojectService.Controllers
{
    public class GameAddressController : TableController<GameAddress>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            gatherteamprojectContext context = new gatherteamprojectContext();
            DomainManager = new EntityDomainManager<GameAddress>(context, Request, Services);
        }

        // GET tables/GameAddress
        public IQueryable<GameAddress> GetAllGameAddress()
        {
            return Query(); 
        }

        // GET tables/GameAddress/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GameAddress> GetGameAddress(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GameAddress/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GameAddress> PatchGameAddress(string id, Delta<GameAddress> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GameAddress/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostGameAddress(GameAddress item)
        {
            GameAddress current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GameAddress/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGameAddress(string id)
        {
             return DeleteAsync(id);
        }

    }
}