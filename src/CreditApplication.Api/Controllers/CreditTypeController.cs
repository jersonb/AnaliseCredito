using CreditApplication.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CreditApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditTypeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.BadRequest)]
        public ActionResult<Result> GetTypeCredits()
        {
            try
            {
                var types = IProposal.OptionsCredit;

                if (types is null)
                {
                    return NotFound(new NotFound(null));
                }
                return Ok(new Sucess(types));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.BadRequest)]
        public ActionResult<Result> GetTypeCreditById(int id)
        {
            try
            {
                var type = IProposal.GetOptionsCredit(id);
                if (type is null)
                {
                    return NotFound(new NotFound(id));
                }
                return Ok(new Sucess(type));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}