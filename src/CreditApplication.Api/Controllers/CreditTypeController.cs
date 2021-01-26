using CreditApplication.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CreditApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditTypeController : ControllerBase
    {
        // GET: api/<CreditController>
        [HttpGet]
        public IEnumerable<string> GetTypeCredits()
        {
            return IProposal.OptionsCredit;
        }

        // GET api/<CreditController>/5
        [HttpGet("{id}")]
        public string GetTypeCreditById(int id)
        {
            return IProposal.GetOptionsCredit(id);
        }
    }
}