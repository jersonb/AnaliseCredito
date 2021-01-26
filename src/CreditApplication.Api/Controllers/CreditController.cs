using CreditApplication.Api.Conditions;
using CreditApplication.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [ProducesResponseType(typeof(DirectRequest), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] DirectRequest proposal)
        {
            try
            {
                _persistence.Log(proposal);

                var credit = proposal.GetCredit();

                if (!credit.Aproved)
                {
                    return UnprocessableEntity(credit);
                }

                var id = _persistence.Save(proposal, credit);

                return Created($"api/credit/{id}", credit);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var credit = _read.GetCredit(id);

                if (credit is null)
                {
                    NotFound(id);
                }
                return Ok(credit);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}