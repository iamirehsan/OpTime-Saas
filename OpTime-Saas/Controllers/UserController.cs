using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpTime_Saas.Base;
using OpTime_Saas.Infrastructure.Base;
using OpTime_Saas.Messages.Commands;
using OpTime_Saas.Service.Interfaces;

namespace OpTime_Saas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceHolder _serviceHolder;

        public UserController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand cmd)
        {
            var result = await _serviceHolder.UserFunctionsService.Login(cmd);
            try
            {
                return Ok(result);
            }

            catch (ManagedException ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(UserCreditCommand cmd)
        {
             await _serviceHolder.UserFunctionsService.CreateUser(cmd);
            try
            {
                return Ok("کاربر ساخنه شد. ");
            }

            catch (ManagedException ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
