using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.ApiEntryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Template_NetCoreApi_DDD.Security;

namespace Template_NetCoreApi_DDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuth]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsService transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            this.transactionsService = transactionsService;
        }

        [HttpPost]
        [Route("Debit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Debit([FromBody]Debit debit)
        {
            try
            {
                var debitTrn = transactionsService.Debit(debit).Result;

                if (debitTrn != null)
                    return StatusCode(200);
                else
                    return StatusCode(400, debit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("Credit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Credit([FromBody]Credit credit)
        {
            try
            {
                var creditTrn = transactionsService.Credit(credit);
                return Ok(creditTrn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Transfer([FromBody]Transfer transfer)
        {
            try
            {
                var transferTrn = transactionsService.Transfer(transfer);
                return Ok(transferTrn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
