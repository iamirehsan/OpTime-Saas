﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpTime_Saas.Base;
using OpTime_Saas.Infrastructure.Base;
using OpTime_Saas.Service.Interfaces;

namespace OpTime_Saas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserCreditController : ControllerBase
    {
        private readonly IServiceHolder _serviceHolder;
        

        public UserCreditController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }
        [HttpGet("GetRoute")]
        public async Task<IActionResult> GetRoute()
        {
            var result = await _serviceHolder.UserCreditService.GetRoute(Token.DeCode(Token.GetToken(this.Request)).userId);
            try
            {

                return Ok(result);

            }
            catch (ManagedException ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("GetDistance")]
        public async Task<IActionResult> GetDistance()
        {
            var result = await _serviceHolder.UserCreditService.GetDistance(Token.DeCode(Token.GetToken(this.Request)).userId);
            try
            {
                return Ok(result);
            }

            catch (ManagedException ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("GetDuration")]
        public async Task<IActionResult> GetDuration()
        {
            var result = await _serviceHolder.UserCreditService.GetDuration(Token.DeCode(Token.GetToken(this.Request)).userId);
            try
            {
                return Ok(result);
            }
            catch (ManagedException ex)
            {

                return BadRequest(ex);
            }
        }
       
       
    }
}
