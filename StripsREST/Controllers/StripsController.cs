using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Mappers;
using StripsREST.Model.Output;

namespace StripsREST.Controllers
{
    [Route("api/[controller]/beheer")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = "http://localhost:5044/api/strips/beheer";

        public StripsController(StripsManager stripsManager)
        {
            this.stripsManager = stripsManager;
        }

        [HttpGet("{id}")]
        public ActionResult<StripRESToutputDTO> GetStrip(int id)
        {
            try
            {
                Strip strip = stripsManager.GeefStrip(id);
                return Ok(MapFromDomain.MapFromStripDomain(url, strip, stripsManager));
            }
            catch (StripsManagerException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
