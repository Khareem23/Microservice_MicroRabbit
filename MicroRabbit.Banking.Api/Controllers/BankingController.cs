using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
       

        private readonly ILogger<BankingController> _logger;
        private readonly IAccountService _accountService;

        public BankingController(ILogger<BankingController> logger,IAccountService accountService )
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_accountService.GetAccounts());
        }
    }
}