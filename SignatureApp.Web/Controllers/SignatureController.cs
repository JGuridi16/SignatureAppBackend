using Microsoft.AspNetCore.Mvc;
using Microsoft.SharePoint.Client;
using SignatureApp.Web.Models;
using SignatureApp.Web.Services;

namespace SignatureApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignatureController : ControllerBase
    {
        private readonly ISignatureService _signatureService;

        public SignatureController(ISignatureService signatureService)
        {
            _signatureService = signatureService;
        }

        [HttpGet]
        public string GetWelcomeMessage()
        {
            return "Welcome";
        }

        [HttpPost("save")]
        public async Task<bool> SaveSignatureData([FromBody] SignatureDto dto)
        {
            return await _signatureService.SaveSignatureDataIntoSharePoint(dto);
        }
    }
}