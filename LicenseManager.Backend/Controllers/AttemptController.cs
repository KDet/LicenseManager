using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using LicenseManager.Backend.DataObjects;
using LicenseManager.Backend.Models;

namespace LicenseManager.Backend.Controllers
{
    public class AttemptController : TableController<Attempt>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            
            DomainManager = new EntityDomainManager<Attempt>(context, Request, Services);
        }

        // GET tables/Attempt
        public IQueryable<Attempt> GetAllAttempt()
        {
            return Query(); 
        }

        // GET tables/Attempt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Attempt> GetAttempt(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Attempt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Attempt> PatchAttempt(string id, Delta<Attempt> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Attempt
        public async Task<IHttpActionResult> PostAttempt(Attempt item)
        {
            Attempt current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Attempt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAttempt(string id)
        {
             return DeleteAsync(id);
        }

    }
}