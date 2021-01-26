using CreditApplication.Api.Conditions;
using CreditApplication.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CreditApplication.Api.Controllers
{
    [Route("api/credit")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly IPersistence _persistence;
        private readonly IRead _read;

        public CreditController(IPersistence persistence, IRead read)
        {
            _persistence = persistence;
            _read = read;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.BadRequest)]
        public ActionResult<Result> Post([FromBody] DirectRequest proposal)
        {
            try
            {
                _persistence.Log(proposal);

                var credit = proposal.GetCredit();

                if (!credit.Aproved)
                {
                    return UnprocessableEntity(new Reproved(credit.Notifications));
                }

                var id = _persistence.Save(proposal, credit);

                return Created($"api/credit/{id}", new Sucess(new { id, proposal, credit }));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new Problem(ex.Message));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Result> Get(string id)
        {
            try
            {
                var credit = _read.GetCredit(id);

                if (credit is null)
                {
                    NotFound(new NotFound(id));
                }
                return Ok(new Sucess(new { credit }));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}